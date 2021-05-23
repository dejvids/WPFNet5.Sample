using ModularWPF.Core;
using ReactiveUI;
using System;

namespace ModularWPF.User.ViewModels
{
    [ViewModel]
    public class WebViewModel : ViewModelBase<string>
    {
        public Uri StartPage { get; set; }

        public override void OnNavigate(string param)
        {
            StartPage = new Uri(param);
            this.RaisePropertyChanged(nameof(StartPage));
        }
    }
}
