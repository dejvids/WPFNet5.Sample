using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace WpfNet5.Core.Services
{
    public class XNavigationService : IXNavigationService
    {
        public XPage CurrentPage { get; private set; }
        private readonly IServiceProvider m_serviceProvider;


        public XNavigationService(IServiceProvider serviceProvider, XPage rootPage)
        {
            m_serviceProvider = serviceProvider;
            CurrentPage = rootPage;
            
        
        }

        public void Navigate<TViewModel>() where TViewModel : XViewModel
        {
            var navigationService = CurrentPage.NavigationService;
            var basePageType = typeof(XPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var destinationPage = Activator.CreateInstance(destinationPageType) as XPage<TViewModel>;
            navigationService.Navigate(destinationPage);
            CurrentPage = destinationPage;
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            CurrentPage.DataContext = viewModel;

            //var httpClient = m_serviceProvider.GetService<HttpClient>();
            viewModel.Init(this, null);

        }
    }
}
