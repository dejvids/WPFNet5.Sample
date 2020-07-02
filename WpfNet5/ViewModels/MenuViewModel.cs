using ReactiveUI;
using System.Reactive;
using WpfNet5.Admin.ViewModels;
using WpfNet5.Core;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class MenuViewModel : XViewModel
    {
        public ReactiveCommand<Unit, Unit> ShowFirstView { get; }
        public ReactiveCommand<Unit, Unit> ShowSecond { get; }
        public ReactiveCommand<Unit, Unit> ShowAdmin { get; }
        public ReactiveCommand<Unit,Unit> ShowUsers { get; }

        public MenuViewModel()
        {
            ShowFirstView = ReactiveCommand.Create(() => NavigationService.Navigate<FirstViewModel>());
            ShowSecond = ReactiveCommand.Create(() => NavigationService.Navigate<SecondViewModel>());
            ShowAdmin = ReactiveCommand.Create(() => NavigationService.Navigate<AdminViewModel>(new { Message = "Hello" }));
            ShowUsers = ReactiveCommand.Create(() => NavigationService.Navigate<UsersViewModel, int>(12));
        }
    }
}