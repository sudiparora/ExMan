using System;
using System.Collections.Generic;
using System.Text;

namespace PerFin.Core
{
    public class DbOperationResult<T>
    {
        public int StatusCode { get; set; }
        public T Result { get; set; }
        public bool IsSuccessful
        {
            get { return StatusCode == 0; }
        }

        public static DbOperationResult<T> ReturnFailureResult()
        {
            //LogFactory.Instance.Error(ex);
            return new DbOperationResult<T> { StatusCode = -999 };
        }
    }
}
