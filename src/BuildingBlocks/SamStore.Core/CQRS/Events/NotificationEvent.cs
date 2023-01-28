using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.CQRS.Events
{
    public class NotificationEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        public NotificationEvent()
        {
            Timestamp = DateTime.Now;
        }
    }
}
