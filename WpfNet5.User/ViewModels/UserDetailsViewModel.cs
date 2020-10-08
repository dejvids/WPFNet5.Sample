using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNet5.User.Models;
using WpfNet5.Core;

namespace WpfNet5.User.ViewModels
{
    public class UserDetailsViewModel: ViewModelBase<Models.User>
    {
        public override void OnNavigate(Models.User param)
        {
            base.OnNavigate(param);
        }
    }
}
