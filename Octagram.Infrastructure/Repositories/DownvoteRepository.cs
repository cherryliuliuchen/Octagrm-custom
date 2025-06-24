using Microsoft.EntityFrameworkCore;
using Octagram.Domain.Entities;
using Octagram.Domain.Repositories;
using Octagram.Infrastructure.Data.Context;

namespace Octagram.Infrastructure.Repositories;

public class DownvoteRepository(ApplicationDbContext context)
    : GenericRepository<Downvote>(context), IDownvoteRepository
{
    public async Task<Downvote?> GetDownvoteByUserAndPostIdAsync(int userId, int postId)
    {
        return await Context.Downvotes
            .FirstOrDefaultAsync(d => d.UserId == userId && d.PostId == postId);
    }

    public async Task<int> GetDownvoteCountForPostAsync(int postId)
    {
        return await Context.Downvotes
            .CountAsync(d => d.PostId == postId);
    }
}