using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using Octagram.Application.Interfaces;
using Octagram.Domain.Entities;
using System.Text.Json;

namespace Octagram.Infrastructure.ExternalServices
{
    public class SqsService : ISqsService
    {
        private readonly IAmazonSQS _sqsClient;
        private readonly string _queueUrl;

        public SqsService(IConfiguration configuration)
        {
            // Get the configuration item and clear the extra spaces
            var accessKey = configuration["AWS:AccessKey"]?.Trim();
            var secretKey = configuration["AWS:SecretKey"]?.Trim();
            var region = configuration["AWS:Region"]?.Trim();
            _queueUrl = configuration["AWS:SQSQueueUrl"]?.Trim();

            Console.WriteLine("🛠️ Initializing SqsService with configuration:");
            Console.WriteLine($"AccessKey: {accessKey}");
            Console.WriteLine($"SecretKey: {secretKey}");
            Console.WriteLine($"Region: {region}");
            Console.WriteLine($"QueueUrl: {_queueUrl}");

            var config = new AmazonSQSConfig
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(region ?? "eu-north-1")
            };

            _sqsClient = new AmazonSQSClient(accessKey, secretKey, config);
        }

        public async Task SendMessageAsync(Notification notification)
        {
            var simplified = new
            {
                NotificationId = notification.Id,
                RecipientId = notification.RecipientId,
                SenderId = notification.SenderId,
                Type = notification.Type,
                TargetId = notification.TargetId,
                MessageId = notification.MessageId,
                Status = notification.Status,
                CreatedAt = notification.CreatedAt
            };

            var messageBody = JsonSerializer.Serialize(simplified);

            var request = new SendMessageRequest
            {
                QueueUrl = _queueUrl,
                MessageBody = messageBody
            };

            try
            {
                var response = await _sqsClient.SendMessageAsync(request);
                Console.WriteLine($"✅ [SQS] Message sent successfully. MessageId={response.MessageId}");
            }
            catch (QueueDoesNotExistException ex)
            {
                Console.WriteLine($"❌ [SQS ERROR] Queue does not exist: {_queueUrl}");
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ [SQS ERROR] Failed to send message.");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
