using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace WpfNet5.Core.Services
{
    public interface IXNavigationService
    {
        Router Router { get; }
        bool CanNavigate { get; }
        bool CanGoBack { get;  }
        ReadOnlyCollection<Type> NavigationHistory { get; }
        void Navigate<TViewModel>(bool preventBackNavigation = false)
            where TViewModel : ViewModelBase;

        void Navigate(object content, bool preventBackNavigation);

        void Navigate<TViewModel>(object parameter, bool preventBackNavigation = false) where TViewModel : ViewModelBase;
        Task NavigateAsync<TViewModel>(object parameter, bool preventBackNavigation = false) where TViewModel : ViewModelBase;
        void Navigate<TViewModel, TParam>(TParam parameter, bool preventBackNavigation = false) where TViewModel : ViewModelBase<TParam>;
        Task NavigateAsync<TViewModel, TParam>(TParam parameter, bool preventBackNavigation = false) where TViewModel : ViewModelBase<TParam>;
        void Navigate<TViewModel, TParam1, TParam2>(TParam1 param1, TParam2 param2, bool preventBackNavigation = false) where TViewModel : ViewModelBase<TParam1, TParam2>;
        Task NavigateAsync<TViewModel, TParam1, TParam2>(TParam1 param1, TParam2 param2, bool preventBackNavigation = false) where TViewModel : ViewModelBase<TParam1, TParam2>;
        void Navigate<TViewModel, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3, bool preventBackNavigation = false) where TViewModel : ViewModelBase<TParam1, TParam2, TParam3>;
        Task NavigateAsync<TViewModel, TParam1, TParam2, TParam3>(TParam1 param1, TParam2 param2, TParam3 param3, bool preventBackNavigation = false) where TViewModel : ViewModelBase<TParam1, TParam2, TParam3>;

        void GoBack();
        internal void StartWithRouter(Router mainRouter);

    }
}
