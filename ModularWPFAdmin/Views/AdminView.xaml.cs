using ModularWPF.Admin.ViewModels;
using ModularWPF.Core;

namespace ModularWPF.Admin.Views
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
