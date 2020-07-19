using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfNet5.Core.Services;

namespace WpfNet5.Core
{
    public class WindowBase : Window
    {
        public event EventHandler RouterCreated;
        protected IXNavigationService navigationService;
        public Router Router { get; protected set; }

        protected void OnRouterCreated(Router instance)
        {
            RouterCreated?.Invoke(instance, new EventArgs());
        }

        
    }
}
