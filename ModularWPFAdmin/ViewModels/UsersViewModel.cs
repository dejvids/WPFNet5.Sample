using ModularWPF.Core;
using ReactiveUI;
using System.Threading.Tasks;

namespace ModularWPF.Admin.ViewModels
{
    [ViewModel]
    public class UsersViewModel: ViewModelBase<int>
    {
        int m_parameter;

        public string Label { get; set; }

        public override void OnNavigate(int param)
        {
            m_parameter = param;
            Label = $"Users - {m_parameter}";
            this.RaisePropertyChanged(nameof(Label));
        }

        public override async Task OnNavigateAsync(int param)
        {
            await Task.Delay(1000);
            OnNavigate(param);
        }
    }
}
