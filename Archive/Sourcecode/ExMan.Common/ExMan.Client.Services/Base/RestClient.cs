using ExMan.Client.Core;
using ExMan.Client.Core.ExceptionHandling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExMan.Client.Services.Base
{
    public class RestClient
    {

        //client.Timeout = new TimeSpan(0, 0, 30);
        //client.BaseAddress = new Uri(baseUri);
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        ////client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        //var content = new List<KeyValuePair<string, string>>();
        //content.Add(new KeyValuePair<string, string>("application/x-www-form-urlencoded", requestUri));

        //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/Token?")
        //{
        //    Content = new FormUrlEncodedContent(content)
        //};
        ////request.Content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        //var response = await client.SendAsync(request);
        //responseObject = await ProcessResponse(responseObject, response).ConfigureAwait(false);


        public async Task<ResponseModel<T>> ExecuteLogin<T>(string baseUri, string username, string encryptedPassword)
        {
            ResponseModel<T> responseObject = new ResponseModel<T>();
            using (HttpClient client = new HttpClient())
            {

                client.Timeout = new TimeSpan(0, 0, 30);
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var tokenModel = new Dictionary<string, string>
                    {
                        {LoginAPIConstants.GRANT_TYPE, LoginAPIConstants.PASSWORD},
                        {LoginAPIConstants.USERNAME, username},
                        {LoginAPIConstants.PASSWORD, encryptedPassword},
                    };

                var response = await client.PostAsync(LoginAPIConstants.LOGINWITHBEARERTOKENAPI, new FormUrlEncodedContent(tokenModel));
                responseObject = await ProcessResponse(responseObject, response).ConfigureAwait(false);
            }
            return responseObject;
        }

        public async Task<ResponseModel<T>> Execute<T>(string baseUri, string requestUri)
        {
            ResponseModel<T> responseObject = new ResponseModel<T>();
            HttpResponseMessage response = new HttpResponseMessage();
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, 30);
                client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocatorService.UserSettingsManager.GetBearerToken());
                response = await client.GetAsync(requestUri).ConfigureAwait(false);
                responseObject = await ProcessResponse(responseObject, response).ConfigureAwait(false);
            }
            return responseObject;
        }

        private async Task<ResponseModel<T>> ProcessResponse<T>(ResponseModel<T> responseObject, HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        responseObject.ServiceOperationResult = ServiceOperationResult.Error;
                        responseObject.Data = default(T);
                        break;
                    case HttpStatusCode.InternalServerError:
                        responseObject.ServiceOperationResult = ServiceOperationResult.Failure;
                        responseObject.Data = default(T);
                        break;
                }
            }
            else
            {
                responseObject.ServiceOperationResult = ServiceOperationResult.Success;
                await ParseAsJson<T>(responseObject, response);
            }
            return responseObject;
        }

        private async Task ParseAsJson<T>(ResponseModel<T> responseObj, HttpResponseMessage response)
        {
            var responseStream = await response.Content.ReadAsStreamAsync();
            using (StreamReader streamReader = new StreamReader(responseStream))
            {
                using (JsonReader jsonReader = new JsonTextReader(streamReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    responseObj.Data = serializer.Deserialize<T>(jsonReader);
                }
            }
        }


    }
}
