using SamStore.Core.CQRS.Events;

namespace SamStore.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime AlteredAt { get; set; } = DateTime.MinValue;
        public bool Removed { get; set; } = false;

        private List<NotificationEvent> _notifications;
        public IReadOnlyCollection<NotificationEvent> Notifications => _notifications?.AsReadOnly();

        public void AddNotificationEvent(NotificationEvent notification)
        {
            _notifications = _notifications ?? new List<NotificationEvent>();
            _notifications.Add(notification);
        }

        public void RemoveNotificationEvent(NotificationEvent notification) 
        {
            _notifications?.Remove(notification);
        }

        public void ClearNotifications()
        {
            _notifications?.Clear();
        }
    }
}
