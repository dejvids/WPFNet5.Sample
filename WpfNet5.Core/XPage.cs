using System;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace WpfNet5.Core
{
    public class XPage : Page
    {
    }

    public class XPage<TViewModel> :XPage where TViewModel: XViewModel
    {
        public TViewModel ViewModel { get; }

        public XPage()
        {
        }

        //public XPage(IServiceProvider serviceProvider)
        //{
        //    ViewModel = serviceProvider.GetRequiredService<TViewModel>();
        //    DataContext = ViewModel;
        //}
    }
}
