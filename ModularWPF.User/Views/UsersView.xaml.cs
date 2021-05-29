using ModularWPF.Core;
using ModularWPF.User.ViewModels;

namespace ModularWPF.User.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UserDetailsView : ContentPage<UserDetailsViewModel>
    {
        public UserDetailsView(UserDetailsViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
