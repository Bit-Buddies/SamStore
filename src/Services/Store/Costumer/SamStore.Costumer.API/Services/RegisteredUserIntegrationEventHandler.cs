using EasyNetQ;
using FluentValidation.Results;
using MediatR;
using SamStore.Core.CQRS.Integrations;
using SamStore.Core.CQRS.Integrations.Abstractions;
using SamStore.Core.CQRS.MediatR;
using SamStore.Costumer.Application.Commands.Customers;
using SamStore.MessageBus;

namespace SamStore.Costumer.API.Services
{
    public class RegisteredUserIntegrationEventHandler : BackgroundService
    {
        private readonly IMessageBus _messageBus; 
        private readonly IServiceProvider _serviceProvider;

        public RegisteredUserIntegrationEventHandler(IServiceProvider serviceProvider, IMessageBus messageBus)
        {
            _serviceProvider = serviceProvider;
            _messageBus = messageBus;
        }

        private void SetResponder()
        {
            _messageBus.RespondAsync<RegisteredUserIntegrationEvent, ResponseMessage>(RegisterCostumer);

            _messageBus.AdvancedBus.Connected += OnConnect; ;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object? sender, ConnectedEventArgs e)
        {
            _messageBus.RespondAsync<RegisteredUserIntegrationEvent, ResponseMessage>(async request =>
            {
                return await RegisterCostumer(request);
            });
        }

        private async Task<ResponseMessage> RegisterCostumer(RegisteredUserIntegrationEvent request)
        {
            ValidationResult result = new ValidationResult();

            using IServiceScope scope = _serviceProvider.CreateScope();

            IMediatorHandler mediatorHandler = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();

            result = await mediatorHandler.SendCommand(new RegisterCustomerCommand(request.Id, request.Name, request.Email, request.CPF));

            return new ResponseMessage(result);
        }
    }
}
