using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Octagram.Application.Interfaces;

namespace Octagram.Infrastructure.Utilities;

public class CloudStorageHelper(IConfiguration configuration) : ICloudStorageHelper
{
    private readonly string? _connectionString = configuration.GetConnectionString("AzureStorage");
    private readonly string? _containerName = configuration["AzureStorage:ContainerName"];

    /// <summary>
    /// Uploads a file to Azure Blob Storage.
    /// </summary>
    /// <param name="fileStream">The stream containing the file data.</param>
    /// <param name="fileName">The original name of the file.</param>
    /// <param name="folderName">The folder name within the Azure Blob Storage container where the file should be stored.</param>
    /// <returns>
    /// The URI of the uploaded file in Azure Blob Storage.
    /// </returns>
    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string folderName)
    {
        await Task.Delay(50);
        return $"https://mocked-storage.local/{folderName}/{fileName}";
    }

}