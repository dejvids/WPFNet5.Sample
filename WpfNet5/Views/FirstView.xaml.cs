﻿using System;
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
using WpfNet5.ViewModels;

namespace WpfNet5.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class FirstView : ContentPage<FirstViewModel>
    {
        [XView(typeof(FirstViewModel))]
        public FirstView()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
        }
    }
}
