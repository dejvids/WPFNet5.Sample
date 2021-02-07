using WpfNet5.Core;
using WpfNet5.ViewModels;

namespace WpfNet5.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class BreadCrumbsView : ContentPage<BreadCrumbsViewModel>
    {
        public BreadCrumbsView()
        {
            InitializeComponent();
        }

        public BreadCrumbsView(BreadCrumbsViewModel viewModel)
        {
            this.ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
