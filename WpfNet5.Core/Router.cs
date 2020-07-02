using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class Router : UserControl
    {
        private ContentPage _currentPage;

        public ContentPage CurrentPage 
        { 
            get { return _currentPage; }
            set { _currentPage = value; } 
        }

        public XViewModel CurrentViewModel { get; set; }

        public static event EventHandler Created;

        public Router()
        {
            Loaded += Router_Loaded;
        }


        private void Router_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ApplicationBase.ServiceProvider != null)
            {
                if(this.Content is ContentPage page)
                {
                    CurrentPage = page;
                    CurrentPage.Launched += RootPageInitialized;
                }

                Created?.Invoke(this, new EventArgs());
            }
        }

        private void RootPageInitialized(object sender, EventArgs e)
        {
            var type = sender.GetType();
            var property = type.GetProperty(nameof(ContentPage<XViewModel>.ViewModel));
            if(property != null)
            {
                CurrentViewModel = property.GetValue(sender) as XViewModel;
            }

            CurrentPage.Launched -= RootPageInitialized;
        }

        internal void Show<TViewModel>(ContentPage<TViewModel> destinationPage) where TViewModel : XViewModel
        {
            Content = destinationPage;
        }

        public void OnNavigated<TViewModel>(TViewModel viewModel)
        {
            CurrentViewModel = viewModel as XViewModel;
        }

        public void OnCLose()
        {
            CurrentViewModel?.OnClose();
        }
    }
}
