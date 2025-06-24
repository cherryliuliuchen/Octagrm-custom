using Octagram.Domain.Entities;

namespace Octagram.Domain.Repositories;

public interface IDownvoteRepository : IGenericRepository<Downvote>
{
    Task<Downvote?> GetDownvoteByUserAndPostIdAsync(int userId, int postId);
    Task<int> GetDownvoteCountForPostAsync(int postId);
}