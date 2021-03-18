using NavigationMVVM.Commands;
using NavigationMVVM.Services;
using NavigationMVVM.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace NavigationMVVM.ViewModels
{
    public class PeopleListingViewModel : ViewModelBase
    {
        private readonly PeopleStore _peopleStore;

        private readonly ObservableCollection<PersonViewModel> _people;

        public IEnumerable<PersonViewModel> People => _people;

        public ICommand AddPersonCommand { get; }

        public PeopleListingViewModel(PeopleStore peopleStore, INavigationService addPersonNavigationService)
        {
            _peopleStore = peopleStore;

            AddPersonCommand = new NavigateCommand(addPersonNavigationService);
            _people = new ObservableCollection<PersonViewModel>();

            _people.Add(new PersonViewModel("SingletonSean"));
            _people.Add(new PersonViewModel("Mary"));
            _people.Add(new PersonViewModel("Joe"));

            _peopleStore.PersonAdded += OnPersonAdded;
        }

        private void OnPersonAdded(string name)
        {
            _people.Add(new PersonViewModel(name));
        }
    }
}
