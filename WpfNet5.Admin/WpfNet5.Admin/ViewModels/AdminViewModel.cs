using System;
using System.Collections.Generic;
using System.Text;
using WpfNet5.Core;

namespace WpfNet5.Admin.ViewModels
{
    [ViewModel]
    public class AdminViewModel : XViewModel
    {
        public object Param { get; private set; }

        private void DoSomething()
        {
            
        }

        public override void OnNavigate(object parameter)
        {
            this.Param = parameter;
        }
    }
}
