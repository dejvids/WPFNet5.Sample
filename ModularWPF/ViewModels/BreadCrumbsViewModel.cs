using ReactiveUI;
using System;
using ModularWPF.Common.Events;
using System.Collections.Generic;
using ModularWPF.Core;

namespace ModularWPF.ViewModels
{
    [ViewModel]
    public class BreadCrumbsViewModel:ViewModelBase
    {
        private string m_breadCrumbs;
        private List<string> m_collection = new List<string>();
        public string BreadCrumbs 
        {
            get { return string.Join("", m_collection); }
        }

        public BreadCrumbsViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<ChangedPage>()
                .Subscribe<ChangedPage>(e => UpdateBreadCrumbs(e));
        }

        private void UpdateBreadCrumbs(ChangedPage e)
        {
            if (e.BreadCrumbs.Equals("BACK") && m_collection.Count > 1)
            {
                m_collection.RemoveAt(m_collection.Count - 1);
            }
            else
            {
                m_collection.Add($"{e.BreadCrumbs}>");
            }

            this.RaisePropertyChanged(nameof(BreadCrumbs));
        }
    }
}
