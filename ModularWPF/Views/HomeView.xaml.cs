using WpfNet5.Core;
using ModularWPF.ViewModels;

namespace ModularWPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : ContentPage<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
        }

        public HomeView(HomeViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }
    }
}
