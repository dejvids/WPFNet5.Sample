using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfNet5.Core
{
    public class ApplicationBase : Application
    {
        public static IServiceProvider ServiceProvider { get; protected set; }
    }
}
