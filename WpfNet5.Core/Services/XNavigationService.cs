using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace WpfNet5.Core.Services
{
    public class XNavigationService : IXNavigationService
    {
        private readonly IServiceProvider m_serviceProvider;
        public Router Router { get; private set; }

        public XNavigationService(IServiceProvider serviceProvider)
        {
            m_serviceProvider = serviceProvider;
        }

        void IXNavigationService.StartWithRouter(Router mainRouter)
        {
            StartWithRouter(mainRouter);
        }

        private void StartWithRouter(Router mainRouter)
        {
            Router = mainRouter;
            Navigate(Router.Content);
        }

        #region NavMethods
        public void Navigate<TViewModel>() where TViewModel : ViewModelBase
        {
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.OnCLose();
            viewModel.OnNavigate(null);
            Router.Show(destinationPage, viewModel);
        }

        public void Navigate<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.CurrentViewModel?.OnClose();
            viewModel.OnNavigate(parameter);
            Router.Show(destinationPage, viewModel);
        }

        public void Navigate<TViewModel, TParam>(TParam param) where TViewModel : ViewModelBase<TParam>
        {
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.CurrentViewModel.OnClose();
            viewModel.OnNavigate(param);
            Router.Show(destinationPage, viewModel);
        }

        public void Navigate<TViewModel, TParam1, TParam2>(TParam1 param1, TParam2 param2) where TViewModel : ViewModelBase<TParam1, TParam2>
        {
            var viewModel = m_serviceProvider.GetService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.OnCLose();
            viewModel.OnNavigate(param1, param2);
            Router.Show(destinationPage, viewModel);
        }

        public void Navigate<TViewModel, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3) where TViewModel : ViewModelBase<TParam1, TParam2, TParam3>
        {
            var viewModel = m_serviceProvider.GetService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.OnCLose();
            viewModel.OnNavigate(param1, param2, param3);
            Router.Show(destinationPage, viewModel);
        }

        public void Navigate(object content)
        {
            object viewModel = null;
            var contentPage = content as ContentPage;
            if (contentPage == null)
                return;

            Type viewModelType = contentPage.GetType().BaseType?.GetGenericArguments()?.FirstOrDefault();
            if (viewModelType != null)
            {
                viewModel = m_serviceProvider.GetService(viewModelType);

                if (viewModel != null)
                {
                    var viewModelProperty = content.GetType().GetProperty(nameof(ContentPage<ViewModelBase>.ViewModel));
                    viewModelProperty.SetValue(content, viewModel);
                }
            }

            Router.OnCLose();
            (viewModel as ViewModelBase)?.OnNavigate(null);
            Router.Show(contentPage, viewModel as ViewModelBase);
        } 
        #endregion

        private static ContentPage<TViewModel> GetView<TViewModel>(TViewModel viewModel) where TViewModel : ViewModelBase
        {
            var basePageType = typeof(ContentPage<TViewModel>);
            var assembly = Assembly.GetAssembly(typeof(TViewModel));

            var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

            ContentPage<TViewModel> destinationPage;
            if (destinationPageType.GetConstructor(new Type[] { typeof(TViewModel) }) != null)
            {
                destinationPage = Activator.CreateInstance(destinationPageType, viewModel) as ContentPage<TViewModel>;
            }
            else
            {
                destinationPage = Activator.CreateInstance(destinationPageType) as ContentPage<TViewModel>;
            }

            return destinationPage;
        }

        //private void Navigate(Type viewModelType)
        //{ //var navigationService = CurrentPage.NavigationService;
        //    var router = GetRouter();
        //    router.OnCLose();
        //    var basePageType = typeof(ContentPage);
        //    basePageType.MakeGenericType(viewModelType);
        //    var assembly = Assembly.GetAssembly(viewModelType);

        //    var destinationPageType = assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(basePageType));

        //    var viewModel = m_serviceProvider.GetRequiredService(viewModelType) as ViewModelBase;
        //    //viewModel.OnNavigate(null);
        //    var destinationPage = Activator.CreateInstance(destinationPageType, viewModel) as ContentPage;

        //    router.Show(destinationPage, viewModel);
        //}

        public void GoBack()
        {
            //TODO: Implement
        }
    }
}
