using WpfNet5.Admin.ViewModels;
using WpfNet5.Core;

namespace WpfNet5.Admin.Views
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
