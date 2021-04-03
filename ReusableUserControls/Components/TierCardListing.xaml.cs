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
    /// Interaction logic for TierCardListing.xaml
    /// </summary>
    public partial class TierCardListing : UserControl
    {
        public TierCardListing()
        {
            InitializeComponent();
        }

        private void OnJoinBasicClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Successfully joined the Basic tier.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnJoinProClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Successfully joined the Pro tier.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnJoinEnterpriseClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Successfully joined the Enterprise tier.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
