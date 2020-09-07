using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using WpfNet5.Core;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class HomeViewModel : ViewModelBase
    {
        string _title = "Home ViewModel";
        public string Title 
        {
            get => _title;
            set { this.RaiseAndSetIfChanged(ref _title, value); }
        }

        public override void OnClose()
        {
            base.OnClose();
        }
    }
}
