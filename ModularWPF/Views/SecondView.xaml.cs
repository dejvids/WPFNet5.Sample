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
using ModularWPF.ViewModels;

namespace ModularWPF.Views
{
    /// <summary>
    /// Interaction logic for SecondPage.xaml
    /// </summary>
    public partial class SecondView : ContentPage<SecondViewModel>
    {
        public SecondView(SecondViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
