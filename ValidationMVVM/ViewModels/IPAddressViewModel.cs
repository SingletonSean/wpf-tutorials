using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ValidationMVVM.Commands;

namespace ValidationMVVM.ViewModels
{
    public class IPAddressViewModel : ViewModelBase
    {
        private string _ipAddressInput;
        public string IPAddressInput
        {
            get
            {
                return _ipAddressInput;
            }
            set
            {
                _ipAddressInput = value;
                OnPropertyChanged(nameof(IPAddressInput));
            }
        }

        public ICommand SubmitIPAddressCommand { get; }

        public IPAddressViewModel()
        {
            SubmitIPAddressCommand = new SubmitIPAddressCommand(this);
        }
    }
}
