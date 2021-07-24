using NavigationMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Stores
{
    public class ModalNavigationStore
    {
        private readonly Stack<ViewModelBase> _viewModelHistory;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                if (_viewModelHistory.Count == 0)
                {
                    return null;
                }

                return _viewModelHistory.Peek();
            }
        }

        public bool IsOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;

        public ModalNavigationStore()
        {
            _viewModelHistory = new Stack<ViewModelBase>();
        }

        public void Push(ViewModelBase viewModel)
        {
            _viewModelHistory.Push(viewModel);
            OnCurrentViewModelChanged();
        }

        public void Pop()
        {
            if (_viewModelHistory.Count == 0)
            {
                return;
            }

            ViewModelBase previousViewModel = _viewModelHistory.Pop();
            previousViewModel.Dispose();

            OnCurrentViewModelChanged();
        }

        public void Close()
        {
            while (_viewModelHistory.Count > 0)
            {
                ViewModelBase previousViewModel = _viewModelHistory.Pop();
                previousViewModel.Dispose();
            }

            OnCurrentViewModelChanged();
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
