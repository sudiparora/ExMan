using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerFin.Client.Model.Base
{
    public class ModelBase : BindableBase, IDataErrorInfo
    {

        #region Fields and Properties

        private Dictionary<string, string> validationErrors;

        public Dictionary<string, string> ValidationErrors
        {
            get
            {
                if (validationErrors == null)
                {
                    validationErrors = new Dictionary<string, string>();
                }
                return validationErrors;
            }
        }

        public virtual string this[string columnName]
        {
            get
            {
                return string.Empty;
            }
        }

        public virtual string Error
        {
            get
            {
                return string.Empty;
            }
        }

        #endregion

        #region Methods

        internal void AddOrUpdateValidationErrors(string propertyName, string errorMessage)
        {
            if (ValidationErrors.Keys.Contains(propertyName))
                ValidationErrors[propertyName] = errorMessage;
            else
                ValidationErrors.Add(propertyName, errorMessage);
        }

        internal void RemoveValidationErrorIfExist(string propertyName)
        {
            ValidationErrors.Remove(propertyName);
        }

        public bool IsValidationSuccessful()
        {
            return ValidationErrors.Count == 0;
        }

        #endregion
    }
}
