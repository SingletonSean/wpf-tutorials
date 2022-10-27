using System;
using System.Windows;
using System.Windows.Input;

namespace EffectiveValidation.UpdateAddress
{
    public class UpdateAddressCommand : ICommand
    {
        private readonly UpdateAddressViewModel _viewModel;
        private readonly UserRepository _userRepository;

        public UpdateAddressCommand(UpdateAddressViewModel updateZipCodeViewModel, UserRepository userRepository)
        {
            _viewModel = updateZipCodeViewModel;
            _userRepository = userRepository;
        }

        public void Execute(object? parameter)
        {
            _viewModel.Validate();

            if (_viewModel.HasErrors)
            {
                return;
            }

            try
            {
                Address address = new Address(
                    _viewModel.AddressLine1,
                    _viewModel.AddressLine2,
                    _viewModel.City,
                    _viewModel.State,
                    _viewModel.ZipCode);

                _userRepository.UpdateAddress(address);

                MessageBox.Show($"Successfully updated address!", "Success", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to update address.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region CanExecute

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        #endregion
    }
}
