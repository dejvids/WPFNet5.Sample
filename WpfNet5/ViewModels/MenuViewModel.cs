using ReactiveUI;
using System.Reactive;
using WpfNet5.Admin.ViewModels;
using WpfNet5.Core;
using WpfNet5.Core.Services;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class MenuViewModel : ViewModelBase
    {
        private readonly IXNavigationService m_navigationService;

        public ReactiveCommand<Unit, Unit> ShowFirst { get; }
        public ReactiveCommand<Unit, Unit> ShowSecond { get; }
        public ReactiveCommand<Unit, Unit> ShowAdmin { get; }
        public ReactiveCommand<Unit, Unit> ShowUsers { get; }


        public MenuViewModel(IXNavigationService navigationService)
        {
            m_navigationService = navigationService;
            ShowFirst = ReactiveCommand.Create(() => m_navigationService.Navigate<FirstViewModel>());
            ShowSecond = ReactiveCommand.Create(() => m_navigationService.Navigate<SecondViewModel>());
            ShowAdmin = ReactiveCommand.Create(() => m_navigationService.Navigate<AdminViewModel>(new { Message = "Hello" }));
            ShowUsers = ReactiveCommand.Create(() => m_navigationService.Navigate<UsersViewModel, int>(12));
        }
    }
}