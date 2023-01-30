using SamStore.Core.CQRS.Events;

namespace SamStore.Costumer.Application.Events.Customers
{
    public class RegisteredCustomerEventHandler : NotificationEventHandler<RegisteredCustomerEvent>
    {
        public override Task Handle(RegisteredCustomerEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
