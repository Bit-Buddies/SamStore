using Microsoft.EntityFrameworkCore;
using SamStore.Core.Domain;
using SamStore.Core.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamStore.Core.CQRS.MediatR
{
    public static class MediatorExtensions
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediatorHandler, T context) where T : DbContext, IUnitOfWork
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearNotifications());

            var tasks = domainEvents
                .Select(async domainEvent => {
                    await mediatorHandler.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
