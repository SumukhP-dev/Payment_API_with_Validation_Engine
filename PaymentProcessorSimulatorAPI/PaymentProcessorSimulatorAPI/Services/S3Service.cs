using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace PaymentProcessingApi.Services
{
    public class S3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3Service(IConfiguration config)
        {
            var region = config["AWS:Region"]; // 👈 from appsettings.json or environment
            _s3Client = new AmazonS3Client(RegionEndpoint.GetBySystemName(region));
            _bucketName = config["S3_BUCKET_NAME"];
        }

        public async Task UploadFileAsync(string filePath, string keyName)
        {
            var transferUtility = new TransferUtility(_s3Client);
            await transferUtility.UploadAsync(filePath, _bucketName, keyName);
        }
    }
}