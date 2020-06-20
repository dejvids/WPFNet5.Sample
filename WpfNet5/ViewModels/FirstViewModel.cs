using System;
using System.Collections.Generic;
using System.Text;
using WpfNet5.Core;

namespace WpfNet5.ViewModels
{
    [ViewModel]
    public class FirstViewModel : XViewModel
    {
        string _title = "First View model";
        public string Title
        {
            get => _title;
            set { _title = value; RaisePropertyChanged(nameof(Title)); }
        }
    }
}
