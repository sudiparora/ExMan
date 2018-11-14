using System;

namespace PerFin.Core
{
    public class OperationResult<T>
    {
        public OperationResult()
        { }

        #region Properties

        public bool IsSuccessful { get; set; }

        public T Result { get; set; }
        
        public int ErrorCode { get; set; }

        #endregion

        #region Methods

        public static OperationResult<T> ReturnOperationResult(DbOperationResult<T> dbOperationResult)
        {
            OperationResult<T> operationResult = new OperationResult<T>();
            operationResult.IsSuccessful = dbOperationResult.IsSuccessful;
            if (!dbOperationResult.IsSuccessful)
            {
                operationResult.ErrorCode = dbOperationResult.StatusCode;
            }
            else
            {
                operationResult.Result = dbOperationResult.Result;
            }
            return operationResult;
        }

        public static OperationResult<T> ReturnFailureResult()
        {
            return new OperationResult<T> { IsSuccessful = false };
        }

        #endregion

    }
}
