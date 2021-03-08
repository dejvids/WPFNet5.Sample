using ReactiveUI;
using ModularWPF.Common.Events;
using WpfNet5.Core;

namespace ModularWPF.ViewModels
{
    [ViewModel]
    public class HomeViewModel : ViewModelBase
    {
        string _title = "Home ViewModel";
        private readonly IEventAggregator m_eventPublisher;

        public string Title 
        {
            get => _title;
            set { this.RaiseAndSetIfChanged(ref _title, value); }
        }

        public HomeViewModel(IEventAggregator eventPublisher)
        {
            m_eventPublisher = eventPublisher;
        }

        public override void OnNavigate(object parameter)
        {
            if (parameter is not null)
            {
                m_eventPublisher.Publish<ChangedPage>(new ChangedPage { BreadCrumbs = "Home" });
            }
        }

        public override void OnClose()
        {
            base.OnClose();
        }
    }
}
