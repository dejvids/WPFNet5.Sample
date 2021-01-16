using WpfNet5.Core;
namespace WpfNet5.Events.Common
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
