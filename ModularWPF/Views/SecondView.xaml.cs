using ModularWPF.ViewModels;
using ModularWPF.Core;

namespace ModularWPF.Views
{
    /// <summary>
    /// Interaction logic for SecondPage.xaml
    /// </summary>
    public partial class SecondView : ContentPage<SecondViewModel>
    {
        public SecondView(SecondViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }
    }
}
