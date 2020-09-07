using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfNet5.Core
{
    public class Router : UserControl
    {
        public ContentPage CurrentPage { get; set; }
        public ViewModelBase CurrentViewModel { get; set; }
        public ViewModelBase HomeViewModel { get; set; }

        Grid grid = new Grid();
        private ProgressBar progressBar;

        public Router()
        {
            progressBar = new ProgressBar()
            {
                IsIndeterminate = true,
                Width = 100,
                Height = 20
            };

            Panel.SetZIndex(progressBar, 100);


        }

        internal void Show<TViewModel>(ContentPage destinationPage, TViewModel viewmodel) where TViewModel : ViewModelBase
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {

                grid.Children.Clear();
                grid.Children.Add(destinationPage);
                grid.IsEnabled = true;

            }));
            OnNavigated(viewmodel);
        }

        internal void Show(ContentPage content, ViewModelBase viewModel)
        {
            grid.Children.Clear();
            Content = grid;
            grid.Children.Add(content);
            grid.IsEnabled = true;
            OnNavigated(viewModel);
        }

        private void OnNavigated(ViewModelBase viewModel)
        {
            if (CurrentViewModel == null)
            {
                HomeViewModel = viewModel;
            }

            CurrentViewModel = viewModel;
        }

        internal void OnClose(bool showProgressBar = false, bool clearContent = false)
        {
            if (clearContent)
            {
                grid.Children.Clear();
            }

            grid.IsEnabled = false;
            if (showProgressBar)
            {
                grid.Children.Add(progressBar);
            }

            CurrentViewModel?.OnClose();

        }
    }
}
