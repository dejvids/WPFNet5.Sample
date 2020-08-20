using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class Router : UserControl
    {
        public ContentPage CurrentPage { get; set; }
        public ViewModelBase CurrentViewModel { get; set; }
        public ViewModelBase HomeViewModel { get; set; }

        public Router()
        {
        }

        internal void Show<TViewModel>(ContentPage destinationPage, TViewModel viewmodel) where TViewModel : ViewModelBase
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                Content = destinationPage;

            }));
            OnNavigated(viewmodel);
        }

        internal void Show(ContentPage content, ViewModelBase viewModel)
        {
            Content = content;
            OnNavigated(viewModel);
        }

        private void OnNavigated(ViewModelBase viewModel)
        {
            if (CurrentViewModel == null)
            {
                HomeViewModel = viewModel;
            }

            CurrentViewModel = viewModel;
        }

        internal void OnCLose()
        {
            CurrentViewModel?.OnClose();
        }
    }
}
