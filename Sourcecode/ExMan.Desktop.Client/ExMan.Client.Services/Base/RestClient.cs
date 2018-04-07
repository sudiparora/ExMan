using ExMan.Client.Core;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Services
{
    public class RestClient
    {

        public async Task<ResponseModel<T>> ExecuteLogin<T>(string baseUri, string requestUri)
        {
            ResponseModel<T> responseObject = new ResponseModel<T>();
            try
            {
                RestSharp.RestClient restClient = new RestSharp.RestClient(baseUri);
                RestRequest restRequest = new RestRequest("/Token", Method.POST);
                string encodedBody = requestUri;
                restRequest.AddParameter("application/x-www-form-urlencoded", encodedBody, ParameterType.RequestBody);
                restRequest.AddParameter("Content-Type", "application/x-www-form-urlencoded", ParameterType.HttpHeader);
                var response = await restClient.ExecuteTaskAsync(restRequest);
                //var response = restClient.Execute(restRequest);
                responseObject = ProcessResponse(responseObject, response);
            }
            catch (Exception ex)
            {

            }
            return responseObject;
        }

        public async Task<ResponseModel<T>> Execute<T>(string baseUri, string requestUri)
        {
            ResponseModel<T> responseObject = new ResponseModel<T>();
            try
            {
                RestSharp.RestClient restClient = new RestSharp.RestClient(baseUri);
                restClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", TokenManager.Instance.GetBearerToken));
                RestRequest restRequest = new RestRequest(requestUri, Method.GET);
                //restRequest.AddHeader("Authorization", string.Format("bearer: {0}", TokenManager.Instance.GetBearerToken));
                //request.AddHeader("Accept", "application/json");
                //request.AddParameter("application/json",
                var response = await restClient.ExecuteTaskAsync(restRequest);
                responseObject = ProcessResponse(responseObject, response);
            }
            catch (Exception ex)
            {

            }
            return responseObject;
        }

        private ResponseModel<T> ProcessResponse<T>(ResponseModel<T> responseObject, IRestResponse restResponse)
        {
            switch (restResponse.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    responseObject.ServiceOperationResult = ServiceOperationResult.Error;
                    responseObject.Data = default(T);
                    break;
                case HttpStatusCode.InternalServerError:
                    responseObject.ServiceOperationResult = ServiceOperationResult.Failure;
                    responseObject.Data = default(T);
                    break;
                case HttpStatusCode.OK:
                    responseObject.ServiceOperationResult = ServiceOperationResult.Success;
                    ParseAsJson<T>(responseObject, restResponse);
                    break;
            }
            return responseObject;
        }

        private void ParseAsJson<T>(ResponseModel<T> responseObj, IRestResponse restResponse)
        {
            responseObj.Data = JsonConvert.DeserializeObject<T>(restResponse.Content);
        }
    }
}
