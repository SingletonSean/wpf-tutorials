using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DragDropDemo.ViewModels
{
    public class TodoItemListingViewModel
    {
        private readonly ObservableCollection<TodoItemViewModel> _todoItemViewModels;

        public IEnumerable<TodoItemViewModel> TodoItemViewModels => _todoItemViewModels;

        public TodoItemListingViewModel()
        {
            _todoItemViewModels = new ObservableCollection<TodoItemViewModel>();
        }

        public void AddTodoItem(TodoItemViewModel item)
        {
            _todoItemViewModels.Add(item);
        }
    }
}
