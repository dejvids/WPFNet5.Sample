using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : XPage<MenuViewModel>
    {
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(MenuViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
        
    }
}