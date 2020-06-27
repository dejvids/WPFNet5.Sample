using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class XViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public event EventHandler Initialized;

        
        public IXNavigationService NavigationService { get; private set; }
        //public HttpClient Http { get; private set; }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Init(IXNavigationService xNavigationService, HttpClient httpClient)
        {
            NavigationService = xNavigationService;
            //Http = httpClient;
        }
    }
}
