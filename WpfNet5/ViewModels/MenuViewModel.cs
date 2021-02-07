using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using WpfNet5.Admin.ViewModels;
using WpfNet5.Common.Events;
using WpfNet5.Core;
using WpfNet5.Core.Services;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class MenuViewModel : ViewModelBase
    {
        private readonly IXNavigationService m_navigationService;
        private readonly IObservable<bool> m_canNavigate;
        private readonly IObservable<bool> m_canGoBack;
        private readonly IEventAggregator m_eventAggregator;

        public bool DataLoaded { get; set; }

        public ReactiveCommand<Unit, Unit> ShowFirst { get; }
        public ReactiveCommand<Unit, Unit> ShowSecond { get; }
        public ReactiveCommand<Unit, Unit> ShowAdmin { get; }
        public ReactiveCommand<Unit, Unit> ShowUsers { get; }
        public ReactiveCommand<Unit, Unit> GoBack { get; }

        public MenuViewModel(IXNavigationService navigationService, IEventAggregator eventAggregator)
        {
            m_navigationService = navigationService;

            m_canNavigate = this.WhenAnyValue(x => x.m_navigationService.CanNavigate, canNavigate => canNavigate == true);
            m_canGoBack = this.WhenAnyValue(x => x.m_navigationService.CanGoBack, x => x.m_navigationService.CanNavigate, (canGoBack, canNavigate) => canGoBack && canNavigate);

            m_eventAggregator = eventAggregator;

            m_eventAggregator.GetEvent<LoadedData>().Subscribe(ev =>
            {
                DataLoaded = ev.Result;
                this.RaisePropertyChanged(nameof(DataLoaded));
            });

            ShowFirst = ReactiveCommand.Create(() =>
            {
                m_navigationService.Navigate<FirstViewModel>();
                m_eventAggregator.Publish<ChangedPage>(new ChangedPage { BreadCrumbs = "First" });
            }, m_canNavigate);

            ShowSecond = ReactiveCommand.Create(() =>
            {
                m_navigationService.Navigate<SecondViewModel>();
                m_eventAggregator.Publish<ChangedPage>(new ChangedPage { BreadCrumbs = "Second" });
            }, m_canNavigate);

            ShowAdmin = ReactiveCommand.CreateFromTask(async() =>
            {
                await m_navigationService.NavigateAsync<AdminViewModel>(new { Message = "Hello" });
                m_eventAggregator.Publish<ChangedPage>(new ChangedPage { BreadCrumbs = "Admin" });
            }, m_canNavigate);

            ShowUsers = ReactiveCommand.CreateFromTask(async () =>
            {
                await m_navigationService.NavigateAsync<UsersViewModel, int>(12);
                m_eventAggregator.Publish<ChangedPage>(new ChangedPage { BreadCrumbs = "Users" });
            }, m_canNavigate);


            GoBack = ReactiveCommand.Create(() =>
            {
                m_navigationService.GoBack();
                m_eventAggregator.Publish<ChangedPage>(new ChangedPage { BreadCrumbs = "BACK" });
            }, m_canGoBack);
        }
    }
}