using ReactiveUI;
using System;
using System.Net.Http;
using System.Reactive;
using System.Threading.Tasks;
using WpfNet5.Core;

namespace WpfNet5.Admin.ViewModels
{
    [ViewModel]
    public class AdminViewModel : ViewModelBase
    {
        private readonly IHttpClientFactory m_http;

        public object Param { get; private set; }

        public string LicenceText { get; private set; }

        public ReactiveCommand<Unit,string> MakeRequestCmd { get; private set; }

        public AdminViewModel(IHttpClientFactory http)
        {
            m_http = http;
        }

        public override async Task OnNavigateAsync(object parameter)
        {
            MakeRequestCmd = ReactiveCommand.CreateFromTask(MakeRequest);
            await Task.Delay(TimeSpan.FromSeconds(5));
            LicenceText = await MakeRequest();
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
