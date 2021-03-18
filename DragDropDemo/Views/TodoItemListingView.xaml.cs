using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragDropDemo.Views
{
    /// <summary>
    /// Interaction logic for TodoItemListingView.xaml
    /// </summary>
    public partial class TodoItemListingView : UserControl
    {
        public static readonly DependencyProperty IsTodoItemHitTestVisibleProperty =
            DependencyProperty.Register("IsTodoItemHitTestVisible", typeof(bool), typeof(TodoItemListingView), 
                new PropertyMetadata(true));

        public bool IsTodoItemHitTestVisible
        {
            get { return (bool)GetValue(IsTodoItemHitTestVisibleProperty); }
            set { SetValue(IsTodoItemHitTestVisibleProperty, value); }
        }

        public static readonly DependencyProperty IncomingTodoItemProperty =
            DependencyProperty.Register("IncomingTodoItem", typeof(object), typeof(TodoItemListingView), 
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public object IncomingTodoItem
        {
            get { return (object)GetValue(IncomingTodoItemProperty); }
            set { SetValue(IncomingTodoItemProperty, value); }
        }

        public static readonly DependencyProperty RemovedTodoItemProperty =
            DependencyProperty.Register("RemovedTodoItem", typeof(object), typeof(TodoItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public object RemovedTodoItem
        {
            get { return (object)GetValue(RemovedTodoItemProperty); }
            set { SetValue(RemovedTodoItemProperty, value); }
        }

        public static readonly DependencyProperty TodoItemDropCommandProperty =
            DependencyProperty.Register("TodoItemDropCommand", typeof(ICommand), typeof(TodoItemListingView), 
                new PropertyMetadata(null));

        public ICommand TodoItemDropCommand
        {
            get { return (ICommand)GetValue(TodoItemDropCommandProperty); }
            set { SetValue(TodoItemDropCommandProperty, value); }
        }

        public static readonly DependencyProperty TodoItemRemovedCommandProperty =
            DependencyProperty.Register("TodoItemRemovedCommand", typeof(ICommand), typeof(TodoItemListingView), 
                new PropertyMetadata(null));

        public ICommand TodoItemRemovedCommand
        {
            get { return (ICommand)GetValue(TodoItemRemovedCommandProperty); }
            set { SetValue(TodoItemRemovedCommandProperty, value); }
        }

        public TodoItemListingView()
        {
            InitializeComponent();
        }

        private void TodoItem_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed &&
                sender is FrameworkElement frameworkElement)
            {
                IsTodoItemHitTestVisible = false;
                DragDrop.DoDragDrop(frameworkElement, 
                    new DataObject(DataFormats.Serializable, frameworkElement.DataContext), 
                    DragDropEffects.Move);
                IsTodoItemHitTestVisible = true;
            }
        }

        private void TodoItemList_Drop(object sender, DragEventArgs e)
        {
            if(TodoItemDropCommand?.CanExecute(null) ?? false)
            {
                IncomingTodoItem = e.Data.GetData(DataFormats.Serializable);
                TodoItemDropCommand?.Execute(null);
            }
        }

        private void TodoItemList_DragLeave(object sender, DragEventArgs e)
        {
            if (TodoItemRemovedCommand?.CanExecute(null) ?? false)
            {
                RemovedTodoItem = e.Data.GetData(DataFormats.Serializable);
                TodoItemRemovedCommand?.Execute(null);
            }
        }
    }
}
