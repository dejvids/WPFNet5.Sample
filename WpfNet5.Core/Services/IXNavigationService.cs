using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Navigation;

namespace WpfNet5.Core.Services
{
    public interface IXNavigationService
    {
        Router RouterContainer { get;}
        void Navigate<TViewModel>()
            where TViewModel : XViewModel;

        void Navigate<TViewModel>(object parameter) where TViewModel : XViewModel;
        void Navigate<TViewModel, TParam>(TParam parameter) where TViewModel : XViewModel<TParam>;

        void GoBack();
    }
}
