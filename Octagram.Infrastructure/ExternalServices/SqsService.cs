// SqsService.cs
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using Octagram.Application.DTOs;
using Octagram.Application.Interfaces;
using System.Text.Json;

namespace Octagram.Infrastructure.ExternalServices;

public class SqsService : ISqsService
{
    private readonly IAmazonSQS _sqsClient;
    private readonly string _queueUrl;

    public SqsService()
    {

        string accessKey = "123456";
        string secretKey = "xQ+123456";
        string region = "eu-north-1";
        _queueUrl = "https://sqs.eu-north-1.amazonaws.com/123456/OctagramNotificationQueueNew";

        var config = new AmazonSQSConfig
        {
            RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(region)
        };

        _sqsClient = new AmazonSQSClient(accessKey, secretKey, config);
    }

    public async Task SendMessageAsync(NotificationDto notificationDto)
    {
        var messageBody = JsonSerializer.Serialize(notificationDto);

        var request = new SendMessageRequest
        {
            QueueUrl = _queueUrl,
            MessageBody = messageBody
        };

        await _sqsClient.SendMessageAsync(request);
    }
}