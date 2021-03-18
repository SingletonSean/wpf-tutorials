using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        public string Name { get; }

        public PersonViewModel(string name)
        {
            Name = name;
        }
    }
}
