using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class Router : UserControl
    {
        public ContentPage CurrentPage { get; set; }

        public XViewModel CurrentViewModel { get; set; }
        public XViewModel HomeViewModel { get; set; }

        public Router()
        {
        }



        internal void Show<TViewModel>(ContentPage<TViewModel> destinationPage, TViewModel viewmodel) where TViewModel : XViewModel
        { 
            Content = destinationPage;
            OnNavigated(viewmodel);
        }

        internal void Show(ContentPage content, XViewModel viewModel)
        {
            Content = content;
            OnNavigated(viewModel);
           
        }

        public void OnNavigated<TViewModel>(TViewModel viewModel)
        {
            if (CurrentViewModel == null)
            {
                HomeViewModel = viewModel as XViewModel;
            }

            CurrentViewModel = viewModel as XViewModel;
        }

        public void OnCLose()
        {
            CurrentViewModel?.OnClose();
        }
    }
}
