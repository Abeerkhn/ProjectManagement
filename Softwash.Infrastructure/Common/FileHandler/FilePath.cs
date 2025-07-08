namespace Softwash.Infrastructure.Common.FileHandler;

public static class FilePath
{
    public static async Task<object> CreateDirectoryy(IHostEnvironment _hostEnvironment)
    {
        string currentDirectory = _hostEnvironment.ContentRootPath;
        currentDirectory += DirectoryName.Name;

        return Directory.CreateDirectory(currentDirectory);
    }
    public static async Task<object> RemoveDirectory(IHostEnvironment _hostEnvironment)
    {
        string currentDirectory = _hostEnvironment.ContentRootPath;
        currentDirectory += DirectoryName.Name;

        if (Directory.Exists(currentDirectory))
            Directory.Delete(currentDirectory, true);

        return true;
    }
    public static async Task<object> UploadFileToDirectory(string fileName, IHostEnvironment _hostEnvironment)
    {
        await RemoveDirectory(_hostEnvironment);
        try
        {
            var url = await DigitalOceanHandler.GetPhotoURL(fileName);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        using (FileStream fileStream = System.IO.File.Create(GetPath(fileName, _hostEnvironment)))
                        {
                            await contentStream.CopyToAsync(fileStream);
                            fileStream.Close();
                        }
                    }
                }

            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static async Task<object> RemoveFileFromDirectory(string fileName, IHostEnvironment _hostEnvironment)
    {
        System.IO.File.Delete(GetPath(fileName, _hostEnvironment));
        return new object();
    }
    public static string GetPath(string fileName, IHostEnvironment _hostEnvironment)
    {
        string currentDirectory = _hostEnvironment.ContentRootPath;
        currentDirectory += DirectoryName.Name;

        Directory.CreateDirectory(currentDirectory);
        currentDirectory += $@"//{fileName}";

        return currentDirectory;

    }
}
