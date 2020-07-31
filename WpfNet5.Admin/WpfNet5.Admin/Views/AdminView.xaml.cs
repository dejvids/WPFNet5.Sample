using WpfNet5.Admin.ViewModels;
using WpfNet5.Core;

namespace WpfNet5.Admin.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : ContentPage<AdminViewModel>
    { 
        public AdminView(AdminViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
