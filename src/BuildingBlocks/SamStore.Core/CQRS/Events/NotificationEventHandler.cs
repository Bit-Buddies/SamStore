using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.CQRS.Events
{
    public abstract class NotificationEventHandler<TNotification> : INotificationHandler<TNotification> where TNotification : NotificationEvent
    {
        public abstract Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}
