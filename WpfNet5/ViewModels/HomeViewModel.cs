using System;
using System.Collections.Generic;
using System.Text;
using WpfNet5.Core;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class HomeViewModel : XViewModel
    {
        string _title = "Home ViewModel";
        public string Title 
        {
            get => _title;
            set { _title = value; RaisePropertyChanged(nameof(Title)); }
        }

        public override void OnClose()
        {
            base.OnClose();
        }
    }
}
