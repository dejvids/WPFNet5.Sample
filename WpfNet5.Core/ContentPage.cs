using System.Windows.Controls;

namespace WpfNet5.Core
{
    public class ContentPage : UserControl
    {
        public ContentPage()
        {
            
        }

        public virtual void OnStart(object obj = null)
        { }
    }

    public class ContentPage<TViewModel> : ContentPage where TViewModel : ViewModelBase
    {
        private TViewModel m_viewModel;
        public TViewModel ViewModel 
        {
            get { return m_viewModel; }
            set { m_viewModel = value; DataContext = m_viewModel; } 
        }

        public ContentPage()
        {
        }

        public ContentPage(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
