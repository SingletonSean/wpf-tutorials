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

        public static readonly DependencyProperty TodoItemInsertedCommandProperty =
            DependencyProperty.Register("TodoItemInsertedCommand", typeof(ICommand), typeof(TodoItemListingView), 
                new PropertyMetadata(null));

        public ICommand TodoItemInsertedCommand
        {
            get { return (ICommand)GetValue(TodoItemInsertedCommandProperty); }
            set { SetValue(TodoItemInsertedCommandProperty, value); }
        }

        public static readonly DependencyProperty InsertedTodoItemProperty =
            DependencyProperty.Register("InsertedTodoItem", typeof(object), typeof(TodoItemListingView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public object InsertedTodoItem
        {
            get { return (object)GetValue(InsertedTodoItemProperty); }
            set { SetValue(InsertedTodoItemProperty, value); }
        }

        public static readonly DependencyProperty TargetTodoItemProperty =
            DependencyProperty.Register("TargetTodoItem", typeof(object), typeof(TodoItemListingView), 
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public object TargetTodoItem
        {
            get { return (object)GetValue(TargetTodoItemProperty); }
            set { SetValue(TargetTodoItemProperty, value); }
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
                object todoItem = frameworkElement.DataContext;

                DragDropEffects dragDropResult = DragDrop.DoDragDrop(frameworkElement, 
                    new DataObject(DataFormats.Serializable, todoItem), 
                    DragDropEffects.Move);

                if(dragDropResult == DragDropEffects.None)
                {
                    AddTodoItem(todoItem);
                }
            }
        }

        private void TodoItem_DragOver(object sender, DragEventArgs e)
        {
            if (TodoItemInsertedCommand?.CanExecute(null) ?? false)
            {
                if(sender is FrameworkElement element)
                {
                    TargetTodoItem = element.DataContext;
                    InsertedTodoItem = e.Data.GetData(DataFormats.Serializable);

                    TodoItemInsertedCommand?.Execute(null);
                }
            }
        }

        private void TodoItemList_DragOver(object sender, DragEventArgs e)
        {
            object todoItem = e.Data.GetData(DataFormats.Serializable);
            AddTodoItem(todoItem);
        }

        private void AddTodoItem(object todoItem)
        {
            if (TodoItemDropCommand?.CanExecute(null) ?? false)
            {
                IncomingTodoItem = todoItem;
                TodoItemDropCommand?.Execute(null);
            }
        }

        private void TodoItemList_DragLeave(object sender, DragEventArgs e)
        {
            HitTestResult result = VisualTreeHelper.HitTest(lvItems, e.GetPosition(lvItems));

            if(result == null)
            {
                if (TodoItemRemovedCommand?.CanExecute(null) ?? false)
                {
                    RemovedTodoItem = e.Data.GetData(DataFormats.Serializable);
                    TodoItemRemovedCommand?.Execute(null);
                }
            }    
        }
    }
}
