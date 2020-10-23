using EventCommands.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventCommands.ViewModels
{
    public class MainViewModel : ObservableObject
    {
		private TodoListViewModel _todoListViewModel;
		public TodoListViewModel TodoListViewModel
		{
			get
			{
				return _todoListViewModel;
			}
			set
			{
				_todoListViewModel = value;
				OnPropertyChanged(nameof(TodoListViewModel));
			}
		}

		public MainViewModel()
		{
			TodoListViewModel = new TodoListViewModel();
		}
	}
}
