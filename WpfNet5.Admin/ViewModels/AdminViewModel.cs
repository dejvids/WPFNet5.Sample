using ReactiveUI;
using System;
using System.Net.Http;
using System.Reactive;
using System.Threading.Tasks;
using WpfNet5.Common;
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

        public ReactiveCommand<Unit,string> MakeRequestCmd { get; private set; }

        public AdminViewModel(IHttpClientFactory http, IEventPublisher eventAggregator)
        {
            m_http = http;
            m_eventAggregator = eventAggregator;
        }

        public override async Task OnNavigateAsync(object parameter)
        {
            MakeRequestCmd = ReactiveCommand.CreateFromTask(MakeRequest);
            await Task.Delay(TimeSpan.FromSeconds(5));
            LicenceText = await MakeRequest();
            m_eventAggregator.Publish<LoadedData>(new LoadedData(true));
            this.RaisePropertyChanged(nameof(LicenceText));
        }

        private async Task<string> MakeRequest()
        {
            using var http = m_http.CreateClient();
            string licence = await http.GetStringAsync("https://raw.githubusercontent.com/kelseyhightower/nocode/master/LICENSE");
            return licence;
        }
    }
}
