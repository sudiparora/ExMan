﻿using System;

namespace ExMan.Shared.Core
{
    public class OperationResult<T>
    {
        private OperationResult()
        { }

        #region Properties

        public bool IsSuccessful { get; private set; }

        public T Result { get; private set; }

        public Exception Exception { get; private set; }

        public string ErrorMessage { get; set; }

        #endregion

        #region Methods

        public static OperationResult<T> ReturnSuccessResult(T result)
        {
            return new OperationResult<T> { IsSuccessful = true, Result = result };
        }

        public static OperationResult<T> LogAndReturnFailureResult(Exception ex, string message = null)
        {
            //LogFactory.Instance.Error(ex);
            return new OperationResult<T> { IsSuccessful = false, Exception = ex, ErrorMessage = message };
        }

        public static OperationResult<T> ReturnFailureResult(string message = null)
        {
            return new OperationResult<T> { IsSuccessful = false, ErrorMessage = message };
        }

        #endregion

    }
}
