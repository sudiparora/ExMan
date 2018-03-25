using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Client.Core
{
    public sealed class ResponseModel<T>
    {
        public ResponseModel()
        { }

        #region Properties

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        public ServiceOperationResult ServiceOperationResult { get; set; }

        /// <summary>
        /// Gets or sets the data collection.
        /// </summary>
        /// <value>
        /// The data collection.
        /// </value>
        public T Data { get; set; }

        public string ErrorMessage { get; set; }

        public int ErrorCode { get; set; }

        #endregion
    }

    public enum ServiceOperationResult
    {
        /// <summary>
        /// Indicates that operation has failed due to some validation logic.
        /// </summary>
        Failure = 0,

        /// <summary>
        /// Indicates that operation has succeeded.
        /// </summary>
        Success = 1,

        /// <summary>
        /// Indicates that operation has encountered an un-handled/custom exception.
        /// </summary>
        Error = 2
    }
}
