using WpfNet5.Core;
using ModularWPF.ViewModels;

namespace ModularWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public MainWindow(MenuViewModel menuViewModel, BreadCrumbsViewModel breadCrumbsViewModel)
        {
            InitializeComponent();
            Router = mainRouter;

            menu.ViewModel = menuViewModel;
            breadCrumbs.ViewModel = breadCrumbsViewModel;
        }
    }
}
