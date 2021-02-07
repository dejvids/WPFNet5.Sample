using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace WpfNet5.Core
{
    public class EventAggregator : IEventAggregator
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
