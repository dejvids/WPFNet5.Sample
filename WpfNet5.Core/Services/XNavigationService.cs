using Microsoft.Extensions.DependencyInjection;
using System;
using System.CodeDom;
using System.Collections.Generic;
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
        public List<Router> RouterContainer { get; private set; } = new List<Router>();

        public XNavigationService(IServiceProvider serviceProvider)
        {
            m_serviceProvider = serviceProvider;

            // ApplicationBase.Instance.RouterCreated += Router_Created;
        }

        //private void Router_Created(object sender, EventArgs e)
        //{
        //    if (RouterContainer == null)
        //        RouterContainer = sender as Router;
        //}

        public void Navigate<TViewModel>() where TViewModel : XViewModel
        {
            //var navigationService = CurrentPage.NavigationService;
            var router = GetRouter();
             router.OnCLose();
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            viewModel.OnNavigate(null);
            ContentPage<TViewModel> destinationPage;
            if (destinationPageType.GetConstructor(new Type[] { typeof(TViewModel) }) != null)
                destinationPage = Activator.CreateInstance(destinationPageType, viewModel) as ContentPage<TViewModel>;
            else
                destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;

            router.Show<TViewModel>(destinationPage, viewModel);
        }

        //private void Navigate(Type viewModelType)
        //{ //var navigationService = CurrentPage.NavigationService;
        //    var router = GetRouter();
        //    router.OnCLose();
        //    var basePageType = typeof(ContentPage);
        //    basePageType.MakeGenericType(viewModelType);
        //    var assembly = Assembly.GetAssembly(viewModelType);

        //    var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

        //    var viewModel = m_serviceProvider.GetRequiredService(viewModelType);
        //    //viewModel.OnNavigate(null);
        //    var destinationPage = Activator.CreateInstance(destinationPageType, viewModel);

        //    router.Show(destinationPage, viewModel);
        //   // router.OnNavigated<TViewModel>(viewModel);
        //}

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void Navigate<TViewModel>(object parameter) where TViewModel : XViewModel
        {
            var router = GetRouter();
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            viewModel.OnNavigate(parameter);
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;
            destinationPage.Initialize(viewModel);

            // destinationPage.OnNavigate(parameter);
            router.Show<TViewModel>(destinationPage, viewModel);
        }

        public void Navigate<TViewModel, TParam>(TParam param) where TViewModel : XViewModel<TParam>
        {
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            viewModel.OnNavigate(param);
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            var destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;
            destinationPage.Initialize(viewModel);

            var router = GetRouter();
            router.Show<TViewModel>(destinationPage, viewModel);
        }

        public void AddRouter(Router mainRouter)
        {
            RouterContainer.Add(mainRouter);
            Navigate(mainRouter.Content);
        }

        private Router GetRouter()
        {
            return RouterContainer.First();
        }

        public void Navigate(object content)
        {
            XViewModel viewModel = null;
            var contentPage = content as ContentPage;
            if (contentPage == null)
                return;

            Type viewModelType = contentPage.GetType().BaseType?.GetGenericArguments()?.FirstOrDefault();
            if (viewModelType != null)
            {
                var vm = m_serviceProvider.GetService(viewModelType);

                if (vm != null)
                {
                    var method = content.GetType().GetMethod("SetViewModel");
                    method.Invoke(content, new[] { vm });

                    viewModel = vm as XViewModel;
                }
            }

            var router = GetRouter();
            router.Show(contentPage, viewModel);
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
