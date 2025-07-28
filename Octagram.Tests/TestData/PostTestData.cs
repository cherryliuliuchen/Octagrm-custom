// File: Octagram.Tests.TestData.PostTestData.cs

using Octagram.Domain.Entities;

namespace Octagram.Tests.TestData
{
    public static class PostTestData
    {
        public static Post CreateSamplePost(int postId, int userId)
        {
            return new Post
            {
                Id = postId,
                UserId = userId,
                Caption = "Test Post",
                CreatedAt = DateTime.UtcNow,
                ImageUrl = "http://example.com/image.jpg"
            };
        }
    }
}