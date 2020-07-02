﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Navigation;

namespace WpfNet5.Core.Services
{
    public interface IXNavigationService
    {
        XPage CurrentPage { get; }
        XViewModel CurrentViewModel { get; }
        Router RouterContainer { get; set; }
        void Navigate<TViewModel>()
            where TViewModel : XViewModel;

        void GoBack();
    }
}
