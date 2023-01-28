using FluentValidation.Results;
using SamStore.Core.CQRS.Commands;

namespace SamStore.Core.CQRS.MediatR
{
    public interface IMediatorHandler 
    {
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
        Task PublishEvent<T>(T eventNotification) where T : Event;
    }
}
