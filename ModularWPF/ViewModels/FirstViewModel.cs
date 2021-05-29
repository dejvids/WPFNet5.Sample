using ModularWPF.Core;
using ReactiveUI;

namespace ModularWPF.ViewModels
{
    [ViewModel]
    public class FirstViewModel : ViewModelBase
    {
        string _title = "First View model";
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
