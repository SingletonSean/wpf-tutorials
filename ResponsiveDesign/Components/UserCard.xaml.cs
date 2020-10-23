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

namespace ResponsiveDesign.Components
{
    public partial class UserCard : UserControl
    {
        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(UserCard), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(UserCard), new PropertyMetadata(0));

        public static readonly DependencyProperty FavoriteColorProperty =
            DependencyProperty.Register("FavoriteColor", typeof(Color), typeof(UserCard), new PropertyMetadata(Color.FromRgb(0, 0, 0)));        
        
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public Color FavoriteColor
        {
            get { return (Color)GetValue(FavoriteColorProperty); }
            set { SetValue(FavoriteColorProperty, value); }
        }

        public UserCard()
        {
            InitializeComponent();
        }
    }
}
