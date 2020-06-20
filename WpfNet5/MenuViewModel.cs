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
        private readonly IXNavigationService _navigationService;

        public ReactiveCommand<Unit, Unit> ShowFirstView { get; }
        public ReactiveCommand<Unit, Unit> ShowSecond { get; }
        public ReactiveCommand<Unit, Unit> ShowAdmin { get; }

        public MenuViewModel(IXNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowFirstView = ReactiveCommand.Create(() => _navigationService.Navigate<FirstViewModel>());
            ShowSecond = ReactiveCommand.Create(() => _navigationService.Navigate<SecondViewModel>());
            ShowAdmin = ReactiveCommand.Create(() => _navigationService.Navigate<AdminViewModel>());
        }
    }
}