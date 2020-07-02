using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class Router : UserControl
    {
        private ContentPage _page;
        public ContentPage Page 
        { 
            get { return _page; }
            set { _page = value; this.Content = _page; } 

        }

        public Router()
        {
            var navigationService = ApplicationBase.ServiceProvider.GetService<IXNavigationService>();
            navigationService.RouterContainer = this;
        }
    }
}
