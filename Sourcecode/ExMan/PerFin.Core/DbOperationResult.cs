using System;
using System.Collections.Generic;
using System.Text;

namespace PerFin.Core
{
    public class DbOperationResult
    {
        public int StatusCode { get; set; }
        public object Result { get; set; }
        public bool IsSuccessful
        {
            get { return StatusCode == 0; }
        }
    }
}
