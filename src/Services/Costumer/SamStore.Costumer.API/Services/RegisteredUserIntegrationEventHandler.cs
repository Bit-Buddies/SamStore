using EasyNetQ;
using FluentValidation.Results;
using MediatR;
using SamStore.Core.CQRS.Integrations;
using SamStore.Core.CQRS.Integrations.Abstractions;
using SamStore.Core.CQRS.MediatR;
using SamStore.Costumer.Application.Commands.Customers;

namespace SamStore.Costumer.API.Services
{
    public class RegisteredUserIntegrationEventHandler : BackgroundService
    {
        private IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegisteredUserIntegrationEventHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus = RabbitHutch.CreateBus("host=localhost:5672");

            _bus.Rpc.RespondAsync<RegisteredUserIntegrationEvent, ResponseMessage>(async request => {
                return new ResponseMessage(await RegisterCostumer(request));
            });

            return Task.CompletedTask;
        }

        private async Task<ValidationResult> RegisterCostumer(RegisteredUserIntegrationEvent request)
        {
            ValidationResult result = new ValidationResult();

            try
            {
                using IServiceScope scope = _serviceProvider.CreateScope();

                IMediatorHandler mediatorHandler = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();

                result = await mediatorHandler.SendCommand(new RegisterCustomerCommand(request.Id, request.Name, request.Email, request.CPF));

                return result;
            }
            catch (Exception ex)
            {
                result.Errors.Add(new ValidationFailure("", $"{ex.Message} - {ex.InnerException}"));
                return result;
            }
        }
    }
}
