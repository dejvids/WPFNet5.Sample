using WpfNet5.User.ViewModels;
using WpfNet5.Core;

namespace WpfNet5.User.Views
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
