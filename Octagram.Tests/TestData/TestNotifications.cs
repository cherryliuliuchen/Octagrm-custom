using System;
using Octagram.Domain.Entities;

namespace Octagram.Tests.TestData
{
    public static class TestNotifications
    {
        public static Notification ValidTestNotification => new Notification
        {
            RecipientId = 999,
            SenderId = 888,
            Type = "test",
            TargetId = null,
            CreatedAt = DateTime.UtcNow,
            IsRead = false,
            MessageId = Guid.NewGuid().ToString(),
            Status = "Pending"
        };
    }
}