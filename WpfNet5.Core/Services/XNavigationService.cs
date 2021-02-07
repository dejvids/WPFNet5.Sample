using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WpfNet5.Core.Services
{
    public class XNavigationService : ReactiveObject, IXNavigationService
    {
        private readonly IServiceProvider m_serviceProvider;

        public Router Router { get; private set; }
        private List<Task> m_naviagationTasks = new List<Task>();
        private bool m_navigating;

        private Stack<Type> m_navigationHistory = new Stack<Type>();

        public ReadOnlyCollection<Type> NavigationHistory => new ReadOnlyCollection<Type>(m_navigationHistory.ToList());
        public bool Navigating
        {
            get { return m_navigating; }
            protected set { this.RaiseAndSetIfChanged(ref m_navigating, value); this.RaisePropertyChanged(nameof(CanNavigate)); }
        }

        public bool CanNavigate => !m_navigating;

        public bool CanGoBack => m_navigationHistory.Count > 1;

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
            Navigate(Router.Content, false);
        }

        #region NavMethods
        public void Navigate<TViewModel>(bool preventBackNavigation) where TViewModel : ViewModelBase
        {
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Task.WaitAll(m_naviagationTasks.ToArray());
            m_naviagationTasks.Clear();

            Router.OnClose();
            viewModel.OnNavigate(null);

            ShowPage(destinationPage, viewModel, preventBackNavigation);

            this.RaisePropertyChanged(nameof(CanGoBack));
        }
        public void Navigate<TViewModel>(object parameter, bool preventBackNavigation) where TViewModel : ViewModelBase
        {
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.CurrentViewModel.OnClose();
            viewModel.OnNavigate(parameter);
            ShowPage(destinationPage, viewModel, preventBackNavigation);
        }

        public async Task NavigateAsync<TViewModel>(object parameter, bool preventBackNavigation) where TViewModel : ViewModelBase
        {
            Navigating = true;

            try
            {
                var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
                var destinationPage = GetView(viewModel);

                Router.OnClose(showProgressBar: true, clearContent: false);
                await viewModel.OnNavigateAsync(parameter);
                ShowPage(destinationPage, viewModel, preventBackNavigation);
            }
            finally
            {
                Navigating = false;
            }
        }

        public void Navigate<TViewModel, TParam>(TParam param, bool preventBackNavigation) where TViewModel : ViewModelBase<TParam>
        {
            var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.CurrentViewModel.OnClose();
            viewModel.OnNavigate(param);
            ShowPage(destinationPage, viewModel, preventBackNavigation);
        }

        public async Task NavigateAsync<TViewModel, TParam>(TParam param, bool preventBackNavigation) where TViewModel : ViewModelBase<TParam>
        {
            Navigating = true;
            try
            {
                var viewModel = m_serviceProvider.GetRequiredService<TViewModel>();
                var destinationPage = GetView(viewModel);

                Router.OnClose(showProgressBar: true);
                await viewModel.OnNavigateAsync(param);
                ShowPage(destinationPage, viewModel, preventBackNavigation);
            }

            finally
            {
                Navigating = false;
            }
        }

        public void Navigate<TViewModel, TParam1, TParam2>(TParam1 param1, TParam2 param2, bool preventBackNavigation) where TViewModel : ViewModelBase<TParam1, TParam2>
        {
            var viewModel = m_serviceProvider.GetService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.OnClose();
            viewModel.OnNavigate(param1, param2);
            ShowPage(destinationPage, viewModel, preventBackNavigation);
        }

        public async Task NavigateAsync<TViewModel, TParam1, TParam2>(TParam1 param1, TParam2 param2, bool preventBackNavigation) where TViewModel : ViewModelBase<TParam1, TParam2>
        {
            Navigating = true;

            try
            {
                var viewModel = m_serviceProvider.GetService<TViewModel>();
                var destinationPage = GetView(viewModel);

                Router.OnClose(true);
                await viewModel.OnNavigateAsync(param1, param2);
                ShowPage(destinationPage, viewModel, preventBackNavigation);
            }
            finally
            {
                Navigating = false;
            }
        }

        public void Navigate<TViewModel, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3, bool preventBackNavigation) where TViewModel : ViewModelBase<TParam1, TParam2, TParam3>
        {
            var viewModel = m_serviceProvider.GetService<TViewModel>();
            var destinationPage = GetView(viewModel);

            Router.OnClose();
            viewModel.OnNavigate(param1, param2, param3);
            ShowPage(destinationPage, viewModel, preventBackNavigation);
        }

        public async Task NavigateAsync<TViewModel, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3, bool preventBackNavigation) where TViewModel : ViewModelBase<TParam1, TParam2, TParam3>
        {
            Navigating = true;

            try
            {
                var viewModel = m_serviceProvider.GetService<TViewModel>();
                var destinationPage = GetView(viewModel);

                Router.OnClose(true);
                await viewModel.OnNavigateAsync(param1, param2, param3);
                ShowPage(destinationPage, viewModel, preventBackNavigation);
            }
            finally
            {
                Navigating = false;
            }
        }

        public void Navigate(object content, bool preventBackNavigation)
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

            Router.OnClose();
            (viewModel as ViewModelBase)?.OnNavigate(new { FirstRun = true });
            Router.Show(contentPage, viewModel as ViewModelBase);

            if (!preventBackNavigation)
            {
                m_navigationHistory.Push(viewModel.GetType());
                this.RaisePropertyChanged(nameof(CanGoBack));
            }
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

        private void ShowPage<TViewModel>(ContentPage page, TViewModel viewModel, bool preventBackNavigation) where TViewModel : ViewModelBase
        {
            Router.Show(page, viewModel);

            if (!preventBackNavigation)
            {
                m_navigationHistory.Push(viewModel.GetType());
                this.RaisePropertyChanged(nameof(CanGoBack));
            }
        }
        public void NavigateBack<TViewModel>() where TViewModel : ViewModelBase
        {
            Navigate<TViewModel>(preventBackNavigation: true);
        }

        public void GoBack()
        {
            if (!CanGoBack)
                throw new InvalidOperationException("Can not navigate back, navigation history is empty.");

            m_navigationHistory.Pop();

            var vm = m_navigationHistory.Peek();

            var method = this.GetType().GetMethod(nameof(NavigateBack));

            method = method.MakeGenericMethod(vm);
            method.Invoke(this, null);
        }
    }
}
