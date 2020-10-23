using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionViewMVVM.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _jobTitle;
        public string JobTitle
        {
            get
            {
                return _jobTitle;
            }
            private set
            {
                _jobTitle = value;
                OnPropertyChanged(nameof(JobTitle));
            }
        }

        public EmployeeViewModel(string name, string jobTitle)
        {
            Name = name;
            JobTitle = jobTitle;
        }
    }
}
