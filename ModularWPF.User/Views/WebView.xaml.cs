using ModularWPF.User.ViewModels;
using ModularWPF.Core;

namespace ModularWPF.User.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class WebView : ContentPage<WebViewModel>
    {
        public WebView(WebViewModel viewModel)
        {
            InitializeComponent();
            this.ViewModel = viewModel;
        }
    }
}
