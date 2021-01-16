using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;
using WpfNet5.Admin.ViewModels;
using WpfNet5.Core;
using WpfNet5.Core.Services;
using WpfNet5.Events.Common;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class MenuViewModel : ViewModelBase
    {
        private readonly IXNavigationService m_navigationService;
        private readonly IObservable<bool> m_canNavigate;
        private readonly IObservable<bool> m_canGoBack;
        private readonly IEventPublisher m_eventAggregator;

        public bool DataLoaded { get; set; }

        public ReactiveCommand<Unit, Unit> ShowFirst { get; }
        public ReactiveCommand<Unit, Unit> ShowSecond { get; }
        public ReactiveCommand<Unit, Unit> ShowAdmin { get; }
        public ReactiveCommand<Unit, Unit> ShowUsers { get; }
        public ReactiveCommand<Unit, Unit> GoBack { get; }

        public MenuViewModel(IXNavigationService navigationService, IEventPublisher eventAggregator)
        {
            m_navigationService = navigationService;

            m_canNavigate = this.WhenAnyValue(x => x.m_navigationService.CanNavigate, canNavigate => canNavigate == true);
            m_canGoBack = this.WhenAnyValue(x => x.m_navigationService.CanGoBack, canGoBack => canGoBack == true);

            m_eventAggregator = eventAggregator;

            m_eventAggregator.GetEvent<LoadedData>().Subscribe(ev =>
            {
                DataLoaded = ev.Result;
                this.RaisePropertyChanged(nameof(DataLoaded));
            });

            ShowFirst = ReactiveCommand.Create(() => m_navigationService.Navigate<FirstViewModel>(), m_canNavigate);
            ShowSecond = ReactiveCommand.Create(() => m_navigationService.Navigate<SecondViewModel>(), m_canNavigate);
            ShowAdmin = ReactiveCommand.CreateFromTask(() => m_navigationService.NavigateAsync<AdminViewModel>(new { Message = "Hello" }), m_canNavigate);
            ShowUsers = ReactiveCommand.CreateFromTask(() => m_navigationService.NavigateAsync<UsersViewModel, int>(12), m_canNavigate);
            GoBack = ReactiveCommand.Create(() => m_navigationService.GoBack(), m_canGoBack);
        }
    }
}