namespace Softwash.Infrastructure.Common.ImageHandler;

public static class ImageHelper
{
    public static string SaveBase64ToFile(string base64String, string folderPath)
    {
        try
        {
            if (string.IsNullOrEmpty(base64String))
            {
                Console.Error.WriteLine("Base64 string is null or empty.");
                return string.Empty;
            }

            var fileName = Guid.NewGuid().ToString() + ".txt";
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var fullFolderPath = Path.Combine(wwwrootPath, folderPath);

            if (!Directory.Exists(fullFolderPath))
            {
                Console.WriteLine("Directory does not exist. Creating directory...");
                Directory.CreateDirectory(fullFolderPath);
            }

            var filePath = Path.Combine(fullFolderPath, fileName);

            File.WriteAllText(filePath, base64String);
            Console.WriteLine("File written successfully.");

            if (File.Exists(filePath))
            {
                Console.WriteLine("File exists after writing.");
            }
            else
            {
                Console.Error.WriteLine("File does not exist after writing.");
                return string.Empty;
            }

            var relativePath = filePath.Substring(wwwrootPath.Length).Replace("\\", "/");
            Console.WriteLine($"Relative path: {relativePath}");

            return relativePath;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error saving file: {ex.Message}");
            return string.Empty;
        }
    }
    public static string ReadFileContent(string relativePath)
    {
        try
        {
            // Ensure the relative path does not start with a backslash
            if (relativePath.StartsWith("\\") || relativePath.StartsWith("/"))
            {
                relativePath = relativePath.TrimStart('\\', '/');
            }

            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var fullPath = Path.Combine(wwwrootPath, relativePath);

            if (!File.Exists(fullPath))
            {
                Console.Error.WriteLine("File does not exist at the specified path.");
                return string.Empty;
            }

            var fileContent = File.ReadAllText(fullPath);
            Console.WriteLine("File read successfully.");
            return fileContent;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error reading file: {ex.Message}");
            return string.Empty;
        }
    }
    public static bool DeleteFile(string relativePath)
    {
        try
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                Console.Error.WriteLine("Relative path is null or empty.");
                return false;
            }

            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            relativePath = relativePath.Replace('/', '\\');
            var fullPath = wwwrootPath + "" + relativePath;

            if (!File.Exists(fullPath))
            {
                Console.Error.WriteLine($"File not found: {fullPath}");
                return false;
            }

            File.Delete(fullPath);
            Console.WriteLine("File deleted successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting file: {ex.Message}");
            return false;
        }
    }
    public static string SaveBase64ToImage(string base64String, string folderPath)
    {
        try
        {
            if (string.IsNullOrEmpty(base64String))
            {
                Console.Error.WriteLine("Base64 string is null or empty.");
                return string.Empty;
            }

            bool IsBase64String(string base64)
            {
                if (string.IsNullOrEmpty(base64))
                    return false;

                // Clean Base64 string by removing any metadata and trimming
                base64 = base64.Trim();
                if (base64.Contains(","))
                    base64 = base64.Split(',')[1];

                // Attempt conversion to check validity
                Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
                return Convert.TryFromBase64String(base64, buffer, out _);
            }

            if (!IsBase64String(base64String))
            {
                Console.Error.WriteLine("Invalid Base64 string.");
                return base64String;
            }

            var fileName = Guid.NewGuid().ToString() + ".jpg";
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var fullFolderPath = Path.Combine(wwwrootPath, folderPath);

            // Create the directory if it doesn't exist
            if (!Directory.Exists(fullFolderPath))
            {
                Console.WriteLine("Directory does not exist. Creating directory...");
                Directory.CreateDirectory(fullFolderPath);
            }

            var filePath = Path.Combine(fullFolderPath, fileName);

            if (base64String.Contains(","))
            {
                base64String = base64String.Split(',')[1];
            }

            byte[] imageBytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(filePath, imageBytes);
            Console.WriteLine("File written successfully.");

            // Verify if the file exists after writing
            if (File.Exists(filePath))
            {
                Console.WriteLine("File exists after writing.");
            }
            else
            {
                Console.Error.WriteLine("File does not exist after writing.");
                return string.Empty;
            }

            // Get the relative path for returning
            var relativePath = filePath.Substring(wwwrootPath.Length).Replace("\\", "/");
            Console.WriteLine($"Relative path: {relativePath}");

            return relativePath;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error saving file: {ex.Message}");
            return string.Empty;
        }
    }
}

