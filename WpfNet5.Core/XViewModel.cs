using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfNet5.Core
{
    public class XViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
