namespace Softwash.Infrastructure.Common.FileHandler;

public static class DigitalOceanHandler
{
    private static IAmazonS3 client;
    private const double DURATION = 24;

    public static async Task<DigitalOceanOutputDTO> UploadBase64(string path, string fileName, string extension)
    {

        client = new AmazonS3Client(DigitalOceanConfiguration.Access_key, DigitalOceanConfiguration.Secret_Key, RegionEndpoint.USEast2);

        string keyName = DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + fileName + "." + extension;
        string base64string = path.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "").Replace("data:image/gif;base64,", "").Replace("data:image/bmp;base64,", "");

        byte[] bytes = Convert.FromBase64String(base64string);
        var request = new PutObjectRequest
        {
            BucketName = DigitalOceanConfiguration.BucketName,
            Key = keyName,
        };

        PutObjectResponse response;
        using (var ms = new MemoryStream(bytes))
        {
            request.InputStream = ms;
            response = await client.PutObjectAsync(request);
        }

        var obj = new DigitalOceanOutputDTO()
        {
            KeyName = keyName,
            BaseUrl = await GetPhotoURL(keyName)
        };

        return obj;
    }

    public static async Task<OutputDTO<string>> GetURL(string key)
    {
        try
        {
            var s3ClientConfig = new AmazonS3Config
            {
                ServiceURL = DigitalOceanConfiguration.EndPointURL
            };

            client = new AmazonS3Client(DigitalOceanConfiguration.Access_key, DigitalOceanConfiguration.Secret_Key, RegionEndpoint.USEast2);

            var request = new GetPreSignedUrlRequest
            {
                BucketName = DigitalOceanConfiguration.BucketName,
                Key = key,
                //Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(DURATION)
            };
            return Output.Handler((int)ResponseType.GET, client.GetPreSignedURL(request));
        }
        catch (Exception ex)
        {
            return Output.Handler<string>((int)ResponseType.NOT_EXIST, null);
        }
    }

    public static async Task<string> GetPhotoURL(string key)
    {
        try
        {
            var s3ClientConfig = new AmazonS3Config
            {
                ServiceURL = DigitalOceanConfiguration.EndPointURL
            };

            client = new AmazonS3Client(DigitalOceanConfiguration.Access_key, DigitalOceanConfiguration.Secret_Key, RegionEndpoint.USEast2);

            if (!(key is null || key is ""))
            {
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = DigitalOceanConfiguration.BucketName,
                    Key = key,
                    Verb = HttpVerb.GET,
                    Expires = DateTime.UtcNow.AddHours(DURATION)
                };

                return client.GetPreSignedURL(request);
            }

            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static string GetPhotoURLs(string key)
    {
        var s3ClientConfig = new AmazonS3Config
        {
            ServiceURL = DigitalOceanConfiguration.EndPointURL
        };

        client = new AmazonS3Client(DigitalOceanConfiguration.Access_key, DigitalOceanConfiguration.Secret_Key, RegionEndpoint.USEast2);

        if (!(key is null || key is ""))
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = DigitalOceanConfiguration.BucketName,
                Key = key,
                Verb = HttpVerb.GET,
                Expires = DateTime.UtcNow.AddHours(DURATION)
            };

            return client.GetPreSignedURL(request);
        }

        return null;
    }

}
