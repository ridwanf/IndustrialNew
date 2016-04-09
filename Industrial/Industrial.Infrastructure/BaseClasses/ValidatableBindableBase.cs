using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Industrial.Infrastructure.BaseClasses
{
    public class ValidatableBindableBase : ViewModelBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            return null;
        }

        public bool HasErrors
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        protected override void SetProperty<T>(ref T member, T val, [CallerMemberName]string propertyName = null)
        {
            base.SetProperty(ref member, val, propertyName);
            ValidateProperty(propertyName, val);
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            var result = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, result);

            if (result.Any())
                _errors[propertyName] = result.Select(c => c.ErrorMessage).ToList<string>();
            else
                _errors.Remove(propertyName);

            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

    }
}