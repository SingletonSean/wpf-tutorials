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

namespace ReusableUserControls.Components
{
    /// <summary>
    /// Interaction logic for TierCard.xaml
    /// </summary>
    public partial class TierCard : UserControl
    {
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(TierCard), 
                new PropertyMetadata(string.Empty));

        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(TierCard), 
                new PropertyMetadata(string.Empty));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(TierCard), 
                new PropertyMetadata(Brushes.Transparent));

        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly RoutedEvent JoinClickEvent =
            EventManager.RegisterRoutedEvent(nameof(JoinClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TierCard));

        public event RoutedEventHandler JoinClick
        {
            add { AddHandler(JoinClickEvent, value); }
            remove { RemoveHandler(JoinClickEvent, value); }
        }

        public TierCard()
        {
            InitializeComponent();
        }

        private void OnJoinClick(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(JoinClickEvent));
        }
    }
}
