using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class XViewModel<TParam>  : XViewModel
    {
        public virtual void OnNavigate(TParam param)
        {
            //base.OnNavigate<TParam>(param);
        }
    }

    public class XViewModel<T1, T2> : XViewModel
    {
        public virtual void OnNavigate(T1 param1, T2 param2)
        {

        }
    }

    public class XViewModel<T1, T2, T3> : XViewModel
    {
        public virtual void OnNavigate(T1 param1, T2 param2, T3 param3)
        {

        }
    }

    public class XViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public event EventHandler Initialized;


       // public IXNavigationService NavigationService => ApplicationBase.ServiceProvider.GetService<IXNavigationService>();
        //public HttpClient Http { get; private set; }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnNavigate(object parameter)
        {

        }

        public virtual void OnClose()
        {

        }

        //public virtual void OnNavigate<TParam>(TParam param)
        //{

        //}

        //public void Init(IXNavigationService xNavigationService, HttpClient httpClient)
        //{
        //    NavigationService = xNavigationService;
        //    //Http = httpClient;
        //}
    }
}
