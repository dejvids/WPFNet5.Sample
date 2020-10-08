using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;
using WpfNet5.Admin.ViewModels;
using WpfNet5.Core;
using WpfNet5.Core.Services;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class MenuViewModel : ViewModelBase
    {
        private readonly IXNavigationService m_navigationService;
        private readonly IObservable<bool> m_canNavigate;

        public ReactiveCommand<Unit, Unit> ShowFirst { get; }
        public ReactiveCommand<Unit, Unit> ShowSecond { get; }
        public ReactiveCommand<Unit, Unit> ShowAdmin { get; }
        public ReactiveCommand<Unit, Unit> ShowUsers { get; }

        public MenuViewModel(IXNavigationService navigationService)
        {
            m_navigationService = navigationService;
            m_canNavigate = this.WhenAnyValue(x => x.m_navigationService.CanNavigate, canNavigate => canNavigate == true);

            ShowFirst = ReactiveCommand.Create(() => m_navigationService.Navigate<FirstViewModel>(), m_canNavigate);
            ShowSecond = ReactiveCommand.Create(() => m_navigationService.Navigate<SecondViewModel>(), m_canNavigate);
            ShowAdmin = ReactiveCommand.CreateFromTask(() => m_navigationService.NavigateAsync<AdminViewModel>(new { Message = "Hello" }), m_canNavigate);
            ShowUsers = ReactiveCommand.CreateFromTask(() => m_navigationService.NavigateAsync<UsersViewModel, int>(12), m_canNavigate);
        }


    }
}