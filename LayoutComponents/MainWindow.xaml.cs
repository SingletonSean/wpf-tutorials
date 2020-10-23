using LayoutComponents.Views;
using System.Windows;

namespace LayoutComponents
{
    public enum ViewType
    {
        Home,
        About
    }

    public partial class MainWindow : Window
    {
        private ViewType _viewType;
        private ViewType ViewType
        {
            get
            {
                return _viewType;
            }
            set
            {
                _viewType = value;
                UpdateView();
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            ViewType = ViewType.Home;
        }

        private void NavHome_Click(object sender, RoutedEventArgs e)
        {
            ViewType = ViewType.Home;
        }

        private void NavAbout_Click(object sender, RoutedEventArgs e)
        {
            ViewType = ViewType.About;
        }

        private void UpdateView()
        {
            switch (ViewType)
            {
                case ViewType.Home:
                    _root.Content = new HomeView();
                    break;
                case ViewType.About:
                    _root.Content = new AboutView();
                    break;
            }
        }
    }
}
