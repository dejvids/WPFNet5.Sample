using System.Windows.Controls;

namespace WpfNet5.Core
{
    public class Router : UserControl
    {
        private Grid m_grid = new Grid();
        private ProgressBar m_progressBar;

        public ContentPage CurrentPage { get; set; }
        public ViewModelBase CurrentViewModel { get; set; }
        public ViewModelBase HomeViewModel { get; set; }

        public Router()
        {
            m_progressBar = new ProgressBar()
            {
                IsIndeterminate = true,
                Width = 100,
                Height = 20
            };

            Panel.SetZIndex(m_progressBar, 100);
        }

        internal void Show<TViewModel>(ContentPage destinationPage, TViewModel viewmodel) where TViewModel : ViewModelBase
        {
            m_grid.Children.Clear();
            m_grid.Children.Add(destinationPage);
            m_grid.IsEnabled = true;
            OnNavigated(viewmodel);
        }

        internal void Show(ContentPage content, ViewModelBase viewModel)
        {
            m_grid.Children.Clear();
            Content = m_grid;
            m_grid.Children.Add(content);
            m_grid.IsEnabled = true;
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
                m_grid.Children.Clear();
            }

            m_grid.IsEnabled = false;
            if (showProgressBar)
            {
                m_grid.Children.Add(m_progressBar);
            }

            CurrentViewModel?.OnClose();
        }
    }
}
