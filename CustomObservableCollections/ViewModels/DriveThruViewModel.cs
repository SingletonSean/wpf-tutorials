using CustomObservableCollections.Commands;
using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace CustomObservableCollections.ViewModels
{
    public class DriveThruViewModel : ViewModelBase
    {
        private readonly ObservableCollection<string> _items;
        private readonly Queue<OrderViewModel> _orders;

        public IEnumerable<string> Items => _items;

        private string _selectedItem;
        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public IEnumerable<OrderViewModel> Orders => _orders;

        public ICommand SubmitOrderCommand { get; }
        public ICommand GiveOrderCommand { get; }

        public DriveThruViewModel()
        {
            _items = new ObservableCollection<string>();
            _orders = new Queue<OrderViewModel>();
            SubmitOrderCommand = new SubmitOrderCommand(this);
            GiveOrderCommand = new GiveOrderCommand(this);

            _items.Add("Chicken");
            _items.Add("Salad");
            _items.Add("Fruit Cup");
        }

        public void SubmitOrder(OrderViewModel order)
        {
            _orders.Enqueue(order);
        }

        public void GiveOrderToCustomer()
        {
            if(_orders.Count > 0)
            {
                _orders.Dequeue();
            }
        }
    }
}
