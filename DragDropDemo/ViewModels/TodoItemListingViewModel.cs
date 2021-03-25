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

        private TodoItemViewModel _insertedTodoItemViewModel;
        public TodoItemViewModel InsertedTodoItemViewModel
        {
            get
            {
                return _insertedTodoItemViewModel;
            }
            set
            {
                _insertedTodoItemViewModel = value;
                OnPropertyChanged(nameof(InsertedTodoItemViewModel));
            }
        }

        private TodoItemViewModel _targetTodoItemViewModel;
        public TodoItemViewModel TargetTodoItemViewModel
        {
            get
            {
                return _targetTodoItemViewModel;
            }
            set
            {
                _targetTodoItemViewModel = value;
                OnPropertyChanged(nameof(TargetTodoItemViewModel));
            }
        }

        public ICommand TodoItemReceivedCommand { get; }
        public ICommand TodoItemRemovedCommand { get; }
        public ICommand TodoItemInsertedCommand { get; }

        public TodoItemListingViewModel()
        {
            _todoItemViewModels = new ObservableCollection<TodoItemViewModel>();

            TodoItemReceivedCommand = new TodoItemReceivedCommand(this);
            TodoItemRemovedCommand = new TodoItemRemovedCommand(this);
            TodoItemInsertedCommand = new TodoItemInsertedCommand(this);
        }

        public void AddTodoItem(TodoItemViewModel item)
        {
            if(!_todoItemViewModels.Contains(item))
            {
                _todoItemViewModels.Add(item);
            }
        }

        public void InsertTodoItem(TodoItemViewModel insertedTodoItem, TodoItemViewModel targetTodoItem)
        {
            if(insertedTodoItem == targetTodoItem)
            {
                return;
            }

            int oldIndex = _todoItemViewModels.IndexOf(insertedTodoItem);
            int nextIndex = _todoItemViewModels.IndexOf(targetTodoItem);

            if(oldIndex != -1 && nextIndex != -1)
            {
                _todoItemViewModels.Move(oldIndex, nextIndex);
            }
        }

        public void RemoveTodoItem(TodoItemViewModel item)
        {
            _todoItemViewModels.Remove(item);
        }
    }
}
