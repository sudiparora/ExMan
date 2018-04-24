﻿using System;

namespace ExMan.Client.Core.ExceptionHandling
{
    public class BaseException : Exception
    {
        public BaseException(string message = "")
            : base(message)
        {
            SetExceptionType();
        }

        public BaseException(Exception ex, string message = "")
            : base(message, ex)
        {
            SetExceptionType();
        }

        public ExceptionType ExceptionType { get; set; }

        public virtual void SetExceptionType() { }
    }

    public enum ExceptionType
    {
        ServiceAccessException = 0
    }
}

