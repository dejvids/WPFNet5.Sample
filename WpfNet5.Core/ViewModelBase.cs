using System.ComponentModel;

namespace WpfNet5.Core
{
    public class ViewModelBase<TParam>  : ViewModelBase
    {
        public virtual void OnNavigate(TParam param)
        {
            
        }
    }

    public class ViewModelBase<T1, T2> : ViewModelBase
    {
        public virtual void OnNavigate(T1 param1, T2 param2)
        {

        }
    }

    public class ViewModelBase<T1, T2, T3> : ViewModelBase
    {
        public virtual void OnNavigate(T1 param1, T2 param2, T3 param3)
        {

        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void OnNavigate(object parameter)
        {

        }

        public virtual void OnClose()
        {

        }
    }
}
