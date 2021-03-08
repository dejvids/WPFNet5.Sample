using WpfNet5.Core;

namespace ModularWPF.Common.Events
{
    public class ChangedPage : EventBase
    {
        public string BreadCrumbs { get; set; }
    }
}
