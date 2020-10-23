using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CollectionViewMVVM.ViewModels
{
    public class EmployeeListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<EmployeeViewModel> _employeeViewModels;

        public IEnumerable<EmployeeViewModel> EmployeeViewModels => _employeeViewModels;

        private string _employeesFilter;
        public string EmployeesFilter
        {
            get
            {
                return _employeesFilter;
            }
            set
            {
                _employeesFilter = value;
                OnPropertyChanged(nameof(EmployeesFilter));
            }
        }

        public EmployeeListingViewModel()
        {
            _employeeViewModels = new ObservableCollection<EmployeeViewModel>();

            foreach (EmployeeViewModel employeeViewModel in GetEmployeeViewModels())
            {
                _employeeViewModels.Add(employeeViewModel);
            }
        }

        private IEnumerable<EmployeeViewModel> GetEmployeeViewModels()
        {
            yield return new EmployeeViewModel("Sean", "Doctor");
            yield return new EmployeeViewModel("Joe", "Firefighter");
            yield return new EmployeeViewModel("Abby", "Web Developer");
            yield return new EmployeeViewModel("Frank", "Construction Worker");
            yield return new EmployeeViewModel("Kate", "Cashier");
            yield return new EmployeeViewModel("Adam", "Accountant");
            yield return new EmployeeViewModel("Mary", "Surgeon");
            yield return new EmployeeViewModel("Tony", "Guitar Player");
        }
    }
}
