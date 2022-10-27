using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EffectiveValidation.UpdateAddress
{
    public class UpdateAddressViewModel : INotifyPropertyChanged, INotifyDataErrorInfo, IAddress
    {
        private readonly AddressValidator _validator = new AddressValidator();

        private string _addressLine1 = string.Empty;
        public string AddressLine1
        {
            get
            {
                return _addressLine1;
            }
            set
            {
                _addressLine1 = value;
                OnPropertyChanged(nameof(AddressLine1));

                ValidateProperty(nameof(AddressLine1));
            }
        }

        private string _addressLine2 = string.Empty;
        public string AddressLine2
        {
            get
            {
                return _addressLine2;
            }
            set
            {
                _addressLine2 = value;
                OnPropertyChanged(nameof(AddressLine2));

                ValidateProperty(nameof(AddressLine2));
            }
        }

        private string _city = string.Empty;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));

                ValidateProperty(nameof(City));
            }
        }

        private string _state = string.Empty;
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));

                ValidateProperty(nameof(State));
            }
        }

        private string _zipCode = string.Empty;
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
                OnPropertyChanged(nameof(ZipCode));

                ValidateProperty(nameof(ZipCode));
            }
        }

        public ICommand UpdateAddressCommand { get; }

        public UpdateAddressViewModel()
        {
            UpdateAddressCommand = new UpdateAddressCommand(this, new UserRepository());
        }

        public void Validate()
        {
            ClearErrors();

            ValidationResult result = _validator.Validate(this);

            IEnumerable<ValidationFailure> errors = result.Errors.DistinctBy(e => e.PropertyName);

            foreach (ValidationFailure error in errors)
            {
                AddError(error.PropertyName, error.ErrorMessage);
            }
        }

        private void ValidateProperty(string propertyName)
        {
            ClearErrors(propertyName);

            ValidationResult result = _validator.Validate(this, o => o.IncludeProperties(propertyName));

            if (result.Errors.Any())
            {
                string firstErrorMessage = result.Errors.First().ErrorMessage;

                AddError(propertyName, firstErrorMessage);
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region INotifyDataErrorInfo

        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, new List<string>());
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        public void ClearErrors()
        {
            _propertyErrors.Clear();
            OnErrorsChanged();
        }

        public void ClearErrors(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

        private void OnErrorsChanged(string? propertyName = null)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #endregion
    }
}
