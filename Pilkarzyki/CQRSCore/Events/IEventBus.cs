using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSCore.Events
{
    public interface IEventBus
    {
        void PublishEvent<T>(T ev) where T : IEvent;
    }
}
