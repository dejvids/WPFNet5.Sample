using WpfNet5.Core;
namespace ModularWPF.Common.Events
{
    public class LoadedData : EventBase
    {
        public LoadedData(bool result)
        {
            Result = result;
        }

        public bool Result { get; set; }
    }
}
