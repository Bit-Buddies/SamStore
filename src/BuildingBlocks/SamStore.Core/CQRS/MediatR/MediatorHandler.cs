using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using SamStore.Core.CQRS.Commands;
using SamStore.Core.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _mediator.Send(command);
        }

        public async Task PublishEvent<T>(T eventNotification) where T : Event
        {
            await _mediator.Publish(eventNotification);
        }
    }
}
