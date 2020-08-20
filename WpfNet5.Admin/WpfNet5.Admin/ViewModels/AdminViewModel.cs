using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
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

        public ReactiveCommand<Unit,Unit> MakeRequestCmd { get; private set; }

        public AdminViewModel(IHttpClientFactory http)
        {
            m_http = http;
        }

        public override void OnNavigate(object parameter)
        {
            this.Param = parameter;
            MakeRequestCmd = ReactiveCommand.Create<Unit>(MakeRequest);
        }

        private Unit MakeRequest()
        {
            using var http = m_http.CreateClient();
            string licence = http.GetStringAsync("https://raw.githubusercontent.com/kelseyhightower/nocode/master/LICENSE").Result;
            LicenceText = licence;
            RaisePropertyChanged(nameof(LicenceText));
            return Unit.Default;
        }
    }
}
