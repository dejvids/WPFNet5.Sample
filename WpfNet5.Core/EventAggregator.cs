using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WpfNet5.Common;

namespace WpfNet5.Core
{
    public class EventAggregator : IEventPublisher
    {
        private ISubject<object> _subject = new Subject<object>();

        public IObservable<TEvent> GetEvent<TEvent>() where TEvent : EventBase
        {
            return _subject.AsObservable().OfType<TEvent>();
        }

        public void Publish<TEvent>(TEvent sampleEvent) where TEvent : EventBase
        {
            _subject.OnNext(sampleEvent);
        }
    }
}
