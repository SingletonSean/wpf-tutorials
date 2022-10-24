using System.Windows;
using EffectiveValidation.UpdateAddress;

namespace EffectiveValidation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new UpdateAddressViewModel();
        }
    }
}
