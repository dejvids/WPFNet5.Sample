using ReactiveUI;
using System.Reactive;
using System.Windows.Input;
using WpfNet5.Admin.ViewModels;
using WpfNet5.Core;
using WpfNet5.Core.Services;
using WpfNet5.ViewModels;

namespace WpfNet5
{
    [ViewModel]
    public class MenuViewModel : XViewModel
    {
        public ReactiveCommand<Unit, Unit> ShowFirstView { get; }
        public ReactiveCommand<Unit, Unit> ShowSecond { get; }
        public ReactiveCommand<Unit, Unit> ShowAdmin { get; }

        public MenuViewModel()
        {
            ShowFirstView = ReactiveCommand.Create(() => NavigationService.Navigate<FirstViewModel>());
            ShowSecond = ReactiveCommand.Create(() => NavigationService.Navigate<SecondViewModel>());
            ShowAdmin = ReactiveCommand.Create(() => NavigationService.Navigate<AdminViewModel>());
        }
    }
}