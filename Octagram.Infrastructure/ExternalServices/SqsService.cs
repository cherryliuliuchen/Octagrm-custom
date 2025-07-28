using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using Octagram.Application.Interfaces;
using System.Text.Json;
using Octagram.Domain.Entities;

namespace Octagram.Infrastructure.ExternalServices
{
    public class SqsService : ISqsService
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly string _queueUrl;

        public SqsService(IConfiguration configuration)
        {
            var config = new AmazonSQSConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.EUNorth1
            };

            _sqsClient = new AmazonSQSClient(
                configuration["Aws:AccessKey"],
                configuration["Aws:SecretKey"],
                config
            );

            _queueUrl = configuration["Aws:QueueUrl"];
        }

        public async Task SendMessageAsync(Notification message)
        {
            var messageBody = JsonSerializer.Serialize(message);

            var request = new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = messageBody
            };

            await _sqsClient.SendMessageAsync(request);
        }
    }
}