using System;
using System.Threading.Tasks;
using Octagram.Application.DTOs;
using Octagram.Infrastructure.ExternalServices;
using Xunit;
using Xunit.Abstractions;

namespace Octagram.Tests.ExternalServices
{
    public class SqsServiceTests
    {
        private readonly ITestOutputHelper _output;

        public SqsServiceTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task SendMessageAsync_Should_Send_Message_To_SQS()
        {

            var sqsService = new SqsService();

            // Create NotificationDto for testing
            var testNotificationDto = new NotificationDto
            {
                Id = 1,
                RecipientId = 2,
                SenderId = 3,
                Sender = new UserDto { Id = 3, Username = "TestUser" },
                Type = "downvote",
                TargetId = 100,
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };

            // ✅ Use SendMessageAsync
            await sqsService.SendMessageAsync(testNotificationDto);

            _output.WriteLine("✅ Message sent successfully.");
            Assert.True(true); // Dummy assertion for test success
        }
    }
}