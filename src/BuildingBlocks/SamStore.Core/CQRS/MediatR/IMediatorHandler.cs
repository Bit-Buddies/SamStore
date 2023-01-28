using FluentValidation.Results;
using SamStore.Core.CQRS.Commands;
using SamStore.Core.CQRS.Events;

namespace SamStore.Core.CQRS.MediatR
{
    public interface IMediatorHandler 
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
        Task PublishEvent<T>(T eventNotification) where T : NotificationEvent;
    }
}
