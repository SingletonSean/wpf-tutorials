using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragDropDemo.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public TodoItemViewModel(string description)
        {
            Description = description;
        }
    }
}
