using Octagram.Domain.Entities;

namespace Octagram.Application.Interfaces;

public interface ISqsService
{
    Task SendMessageAsync(Notification notification);
}