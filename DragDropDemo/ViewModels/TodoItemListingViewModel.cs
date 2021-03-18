using DragDropDemo.Commands;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace DragDropDemo.ViewModels
{
    public class TodoItemListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<TodoItemViewModel> _todoItemViewModels;

        public IEnumerable<TodoItemViewModel> TodoItemViewModels => _todoItemViewModels;

        private TodoItemViewModel _incomingTodoItemViewModel;
        public TodoItemViewModel IncomingTodoItemViewModel
        {
            get
            {
                return _incomingTodoItemViewModel;
            }
            set
            {
                _incomingTodoItemViewModel = value;
                OnPropertyChanged(nameof(IncomingTodoItemViewModel));
            }
        }

        private TodoItemViewModel _removedTodoItemViewModel;
        public TodoItemViewModel RemovedTodoItemViewModel
        {
            get
            {
                return _removedTodoItemViewModel;
            }
            set
            {
                _removedTodoItemViewModel = value;
                OnPropertyChanged(nameof(RemovedTodoItemViewModel));
            }
        }

        public ICommand TodoItemReceivedCommand { get; }
        public ICommand TodoItemRemovedCommand { get; }

        public TodoItemListingViewModel()
        {
            _todoItemViewModels = new ObservableCollection<TodoItemViewModel>();

            TodoItemReceivedCommand = new TodoItemReceivedCommand(this);
            TodoItemRemovedCommand = new TodoItemRemovedCommand(this);
        }

        public void AddTodoItem(TodoItemViewModel item)
        {
            if(!_todoItemViewModels.Contains(item))
            {
                _todoItemViewModels.Add(item);
            }
        }

        public void RemoveTodoItem(TodoItemViewModel item)
        {
            _todoItemViewModels.Remove(item);
        }
    }
}
