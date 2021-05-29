using ModularWPF.Admin.ViewModels;
using ModularWPF.Core;

namespace ModularWPF.Admin.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : ContentPage<UsersViewModel>
    {
        public UsersView(UsersViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
