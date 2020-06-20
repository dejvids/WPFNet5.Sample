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
using WpfNet5.Core;

namespace WpfNet5
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class NavMenu : UserControl
    {
        public NavMenu()
        {
            InitializeComponent();
        }
        public void Init(MenuViewModel menuViewModel)
        {
            var menuPage = new Menu();
            menuPage.DataContext = menuViewModel;
            menuFrame.Navigate(menuPage);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
