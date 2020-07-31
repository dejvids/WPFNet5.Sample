using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Navigation;

namespace WpfNet5.Core.Services
{
    public interface IXNavigationService
    {
        Router Router  {get;}
        void Navigate<TViewModel>()
            where TViewModel : ViewModelBase;

        void Navigate(object content);

        void Navigate<TViewModel>(object parameter) where TViewModel : ViewModelBase;
        void Navigate<TViewModel, TParam>(TParam parameter) where TViewModel : ViewModelBase<TParam>;

        void GoBack();
        internal void StartWithRouter(Router mainRouter);

    }
}
