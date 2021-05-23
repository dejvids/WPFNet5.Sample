using ModularWPF.ViewModels;
using ModularWPF.Core;

namespace ModularWPF.Views
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
    public partial class FirstView : ContentPage<FirstViewModel>
    {
        public FirstView(FirstViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
