using ReactiveUI;
using System;
using System.Net.Http;
using System.Reactive;
using System.Threading.Tasks;
using WpfNet5.Events.Common;
using WpfNet5.Core;

namespace WpfNet5.Admin.ViewModels
{
    [ViewModel]
    public class AdminViewModel : ViewModelBase
    {
        private readonly IHttpClientFactory m_http;
        private readonly IEventPublisher m_eventAggregator;

        public object Param { get; private set; }

        public string LicenceText { get; private set; }

        public ReactiveCommand<Unit, Unit> MakeRequestCmd { get; private set; }

        public AdminViewModel(IHttpClientFactory http, IEventPublisher eventAggregator)
        {
            m_http = http;
            m_eventAggregator = eventAggregator;

            MakeRequestCmd = ReactiveCommand.CreateFromTask(MakeRequest);
        }

        public override async Task OnNavigateAsync(object parameter)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            await MakeRequest();

            m_eventAggregator.Publish<LoadedData>(new LoadedData(true));
        }

        private async Task MakeRequest()
        {
            using var http = m_http.CreateClient();
            string licence = await http.GetStringAsync("https://raw.githubusercontent.com/kelseyhightower/nocode/master/LICENSE");
            LicenceText = licence;
            this.RaisePropertyChanged(nameof(LicenceText));
        }
    }
}
