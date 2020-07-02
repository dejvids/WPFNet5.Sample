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
        private readonly IServiceProvider m_serviceProvider;
        public Router RouterContainer { get; private set; }


        public XNavigationService(IServiceProvider servicePRovider)
        {
            m_serviceProvider = servicePRovider;
            Router.Created += Router_Created;
        }

        private void Router_Created(object sender, EventArgs e)
        {
            if (RouterContainer == null)
                RouterContainer = sender as Router;
        }

        public void Navigate<TViewModel>() where TViewModel : XViewModel
        {
            //var navigationService = CurrentPage.NavigationService;
            RouterContainer.OnCLose();
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;
            var viewModel = ApplicationBase.ServiceProvider.GetRequiredService<TViewModel>();
            viewModel.OnNavigate(null);

            RouterContainer.Show(destinationPage);
            RouterContainer.OnNavigated<TViewModel>(viewModel);
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void Navigate<TViewModel>(object parameter) where TViewModel : XViewModel
        {
            var viewModel = ApplicationBase.ServiceProvider.GetRequiredService<TViewModel>();
            viewModel.OnNavigate(parameter);
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;
            destinationPage.Initialize(viewModel);

            // destinationPage.OnNavigate(parameter);
            RouterContainer.Content = destinationPage;
            RouterContainer.OnNavigated<TViewModel>(viewModel);
        }

        public void Navigate<TViewModel, TParam>(TParam param) where TViewModel : XViewModel<TParam>
        {
            var viewModel = ApplicationBase.ServiceProvider.GetRequiredService<TViewModel>();
            viewModel.OnNavigate(param);
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;
            destinationPage.Initialize(viewModel);

            RouterContainer.Content = destinationPage;
            RouterContainer.OnNavigated<TViewModel>(viewModel);

        }
    }
}
