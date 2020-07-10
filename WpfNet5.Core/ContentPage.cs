using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfNet5.Core
{
    public class ContentPage : UserControl
    {
        public event EventHandler Launched;

        protected void OnLaunched(object sender, EventArgs e)
        {
            Launched?.Invoke(sender, e);
    }
    }

    public class ContentPage<TViewModel> : ContentPage where TViewModel : XViewModel
    {
        public TViewModel ViewModel { get; protected set; }

        public ContentPage()
        {
            this.Loaded += ContentPage_Loaded;
        }

        private void ContentPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ViewModel == null && ApplicationBase.ServiceProvider != null)
            {
                ViewModel = ApplicationBase.ServiceProvider.GetService<TViewModel>();
            }

            this.DataContext = ViewModel;
            OnLaunched(this, new EventArgs());
        }

        public void Initialize(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
