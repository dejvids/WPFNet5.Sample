using ReactiveUI;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfNet5.Core
{
    public class ViewModelBase<TParam>  : ViewModelBase
    {
        public virtual void OnNavigate(TParam param)
        {    
        }

        public virtual Task OnNavigateAsync(TParam param)
        {
            return Task.CompletedTask;
        }
    }

    public class ViewModelBase<T1, T2> : ViewModelBase
    {
        public virtual void OnNavigate(T1 param1, T2 param2)
        {
        }
        public virtual Task OnNavigateAsync(T1 param1, T2 param2)
        {
            return Task.CompletedTask;
        }
    }

    public class ViewModelBase<T1, T2, T3> : ViewModelBase
    {
        public virtual void OnNavigate(T1 param1, T2 param2, T3 param3)
        {
        }

        public virtual Task OnNavigateAsync(T1 param1, T2 param2, T3 param3)
        {
            return Task.CompletedTask;
        }
    }

    public class ViewModelBase : ReactiveObject, INotifyPropertyChanged
    {
        public virtual void OnNavigate(object parameter)
        {

        }

        public virtual Task OnNavigateAsync(object parameter)
        {
            return Task.CompletedTask;
        }

        public virtual void OnClose()
        {
            
        }
    }
}
