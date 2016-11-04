using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSCore.Events
{
    public class EventBus : IEventBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvent>> handlersFactory;

        public void PublishEvent<T>(T ev) where T : IEvent
        {
            var handlers = handlersFactory(typeof(T))
                .Cast<IHandleEVent<T>>();

            foreach (var handler in handlers)
            {
                handler.Handle(ev);
            }
        }

        public EventBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
        {
            this.handlersFactory = handlersFactory;
        }
    }
}
