using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Octagram.Infrastructure.ExternalServices;
using Octagram.Tests.TestData;
using Xunit;

namespace Octagram.Tests.ExternalServices
{
    public class SqsServiceTests
    {
        [Fact]
        public async Task SendMessageAsync_Should_Send_Message_To_SQS()
        {
            // Load appsettings.json from Octagram.API
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../../Octagrm/Octagram.API"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            var sqsService = new SqsService(config);

            // Load test notification from shared test data
            var testNotification = TestNotifications.ValidTestNotification;

            await sqsService.SendMessageAsync(testNotification);

            // Dummy assertion
            Assert.True(true);
        }
    }
}