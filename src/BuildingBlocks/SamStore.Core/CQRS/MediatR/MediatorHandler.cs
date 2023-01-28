using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using SamStore.Core.CQRS.Commands;
using SamStore.Core.CQRS.Events;

namespace SamStore.Core.CQRS.MediatR
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly ILogger<MediatorHandler> _logger;
        private readonly IMediator _mediator;

        public MediatorHandler(ILogger<MediatorHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            _logger.LogInformation($"Executando comando {command.MessageType}");
            return await _mediator.Send(command);
        }

        public async Task PublishEvent<T>(T eventNotification) where T : NotificationEvent
        {
            _logger.LogInformation($"Executando evento {eventNotification.MessageType}");
            await _mediator.Publish(eventNotification);
        }
    }
}
