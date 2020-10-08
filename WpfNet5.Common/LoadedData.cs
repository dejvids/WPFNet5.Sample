using System;
namespace WpfNet5.Common
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
