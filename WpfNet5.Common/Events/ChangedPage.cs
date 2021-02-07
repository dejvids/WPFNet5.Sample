using WpfNet5.Core;

namespace WpfNet5.Common.Events
{
    public class ChangedPage : EventBase
    {
        public string BreadCrumbs { get; set; }
    }
}
