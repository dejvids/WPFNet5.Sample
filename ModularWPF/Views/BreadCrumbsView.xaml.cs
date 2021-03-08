using WpfNet5.Core;
using ModularWPF.ViewModels;

namespace ModularWPF.Views
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
