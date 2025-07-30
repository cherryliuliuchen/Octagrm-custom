using Octagram.Application.DTOs;

namespace Octagram.Application.Interfaces;

public interface ISqsService
{
    Task SendMessageAsync(NotificationDto notificationDto);
}