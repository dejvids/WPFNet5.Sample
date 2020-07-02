using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace WpfNet5.Core.Services
{
    public class XNavigationService : IXNavigationService
    {
        public XPage CurrentPage { get; private set; }
        public XViewModel CurrentViewModel { get; protected set; }

        private readonly IServiceProvider m_serviceProvider;
        public Router RouterContainer { get; set; }


        public XNavigationService(IServiceProvider serviceProvider, XPage rootPage)
        {
            m_serviceProvider = serviceProvider;
            CurrentPage = rootPage;
        }

        public void Navigate<TViewModel>() where TViewModel : XViewModel
        {
            //var navigationService = CurrentPage.NavigationService;
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;
            RouterContainer.Content = destinationPage;
            //navigationService.Navigate(destinationPage);
            //CrrentPage = destinationPage;
            //var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            //CurrentPage.DataContext = viewModel;

            ////var httpClient = m_serviceProvider.GetService<HttpClient>();
            //CurrentViewModel = viewModel;

        }

        public void GoBack()
        {
            if(this.CurrentPage.NavigationService.CanGoBack)
                this.CurrentPage.NavigationService.GoBack();
        }
    }
}
