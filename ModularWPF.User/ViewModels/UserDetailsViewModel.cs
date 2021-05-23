using ModularWPF.Core;

namespace ModularWPF.User.ViewModels
{
    public class UserDetailsViewModel: ViewModelBase<Models.User>
    {
        public override void OnNavigate(Models.User param)
        {
            base.OnNavigate(param);
        }
    }
}
