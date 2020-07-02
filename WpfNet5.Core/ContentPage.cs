using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfNet5.Core
{
    public class ContentPage : UserControl
    {
    }

    public class ContentPage<TViewModel> : ContentPage where TViewModel : XViewModel
    {
        private TViewModel m_viewModel;
        private object m_dataContext;
        public TViewModel ViewModel => ApplicationBase.ServiceProvider.GetService<TViewModel>();
        //{ 
        //    get 
        //    {
        //        return 
        //        if (m_viewModel == null)
        //        {
        //            m_viewModel = ApplicationBase.ServiceProvider.GetService<TViewModel>();
        //            DataContext = m_viewModel;
        //        }
        //        return m_viewModel;
        //    } 
        //}

        //public new object DataContext { get { return base.DataContext ?? ViewModel; } set { base.DataContext = value; } }
    }
}
