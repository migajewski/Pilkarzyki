using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSCore.Events
{
    public interface IHandleEvent : IEvent
    {

    }

    public interface IHandleEVent<TEvent> : IHandleEvent
    where TEvent : IEvent
    {
        void Handle(TEvent ev);
    }
}
