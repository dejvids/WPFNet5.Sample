using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNet5.Core;

namespace WpfNet5.Admin.ViewModels
{
    [ViewModel]
    public class UsersViewModel: XViewModel<int>
    {
        int m_parameter;

        public string Label { get; set; }

        public override void OnNavigate(int param)
        {
            m_parameter = param;
            Label = "Users";
            RaisePropertyChanged(nameof(Label));
        }
    }
}
