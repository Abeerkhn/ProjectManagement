using System.Security.Cryptography.X509Certificates;

namespace Softwash.Infrastructure.Common;

public static class Twillio
{
    public const string AccountSID = "";
    public const string AccountToken = "";
    public const string Number = "";
}

public static class ShopifyStore
{
    private static string _baseUrlTemplate = "https://{0}.myshopify.com/admin/api/2024-10/";
    public static string BuildBaseUrl(string storeName)
    {
        if (string.IsNullOrEmpty(storeName))
            throw new ArgumentNullException(nameof(storeName));

        return string.Format(_baseUrlTemplate, storeName);
    }
}

public static class SendGridKey
{
    public const string Key = "";
    public const string Username = "Softwash";
    public const string Email = "";
}

public static class DirectoryName
{
    public const string Name = "UploadFiles";
}

public static class DigitalOceanConfiguration
{
    public const string BucketName = "";
    public const string Access_key = "";
    public const string Secret_Key = "";
    public const string EndPointURL = "http://softwas-apis.rootpointers.net/swagger/index.html";
}

public static class StripeKey
{
    //dev
    public const string ApiKey = "";

    // pro
    //public const string ApiKey = "";
}

public static class StripeConnectedAccount
{
    // dev
    //public const string RefreshUrl = "";
    //public const string ReturnUrl = ";

    // pro
    public const string RefreshUrl = "";
    public const string ReturnUrl = "";
}

public class SessionProperty
{
    public const string UserId = "UserId";
    public const string EmailOrPhoneNumber = "EmailOrPhoneNumber";
}

public class JWTKey
{
    public const string Key = "This is a JWT Key for Authentication and Authorization of the users.";
}

public static class Firebase
{
    public const string json = @"{
  ""type"": ""service_account"",
  ""project_id"": ""sesw-c75c9"",
  ""private_key_id"": ""45bdabc15922a192fb492db45b283bd32a7b04c4"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvAIBADANBgkqhkiG9w0BAQEFAASCBKYwggSiAgEAAoIBAQCY4VbfwvaWUKe6\nM+oiHCJ3VIM74qFKlvLoG5NggUZUVNSmzEvzuvoh7XcSKABmhu2BepZywbqRqW2U\nofsNemgOW0ZJLjKRO23uVgO+0ewYuGpdfCe78lBENfliP+EKQaU0Gg1aYR8TQ9zw\nBw6pLq2SRntMukPpMNM/p2y+CjVJEb+amPxmXgHYENc0zhlilHBaVwrHqlzcY+kh\nB5ckmA+mLa2pL5rtE0ek1FfRPHOPJv88TANbYOiQW51U++IH/uyOzaFSj5s60eE2\nY05jUScKllmALgw0tAo/Gh4haaBOjRHeUKNARdXe7Wasuu4bvR78zHJd4s/LXw/L\nQx+FVtgHAgMBAAECggEAQo4fVuy2kzvruSlurYjYDGEzfLeuBh3vA9M1dtbwujfw\nF+lqy2HEEU8i/jmB6yCkdzDaHH1wbod3GDToaba3ZECiOauuAgIAWrkBimozQZPP\nYoFxfuX/waJJvlcW7nMjq6oH1Cfh8m4h2jEIVejnUX3zobSZagSCgvytX5JsHjG6\nEYnKuP7TPbS+2qHst1pyWNbk98sicw+vSl3r8A6rlK8naSS6EcSK3aduNJVnRrxR\nzC3VbM0aRAjg5it4OwpCLKbinaOvLo3xgEK5y7DgzWSLyFxxgc8lb1vl3t9Xh1Ee\nGSuEhhjGHdcIsgl45KffY9+K5d+Ocoe3vkaK32MU+QKBgQDWFSocF/ACyfoLPUAK\n5ojf06fHAUkDQ7UGnBDAMS2YsBJz4h/70Q3jaXaiYRz8iN3jXg0vg8eNWJewCZ6a\nOjgABVNoCvklnAOqMekNo8uYM5qcHhvBbceO2J9XehG3IsE66scZk/jNYralxzAW\nVUM13dLP/z4KuFgSTS5pqQe8OwKBgQC20GtPy0VWwiTuxMoUrqQIA1AuzK/pqQe6\ntQLXpqGNI4Bo8cLHBkigkk8OvjvWfifMJCn6f/U+vwlShh+NwBkoJLj1XE/dJ3Vk\nyQ7uFDV9e/F5M03BXe2qC3m7rFSPdxJFhzs1egrLdyJMx8T6Q+PC2INeAMRnmJNP\nzt5Vo1UypQKBgGwMkI1PU5bExAuqJUmbIxf85mAdePFJ2fL1D8tAxueabiXIyiW5\nVI4jq3m3E/8tQPhBftwtYakoPp7drAvhOGRiS79mUms1+++JczusINS3rt/+njmZ\nI7AoCvwGoyxQQUBwQH7bXSakHNU83DtZWyuzwnOyOmkEs4bBJ5yycDIDAoGAUwA/\nqKPWoHRXBl0sjsVXzheLASSHveOzka57UuPht03mED+rumb89IJZCI2QZ2sxsHq+\n4G/WLh3YIrKogtgz08kQfL3juLogj5jFgYyFWKq8UNXdOKznqeu54l50qgparlye\nokH9wrEdTpTotuO59g4NXtGkWpCoWXTH90PH+80CgYBVX4J8dW5PVhqexwqs86t5\nE4yANtly7S2SbGrzO4jhhEaBzOzFyPey/CMEMXi9gLhD/tK8GvEsliG0foc9I3eO\nqHVUl0AvJa7hp97EkSjMhNnHiJSkyZZJxc+xGMSJJ7HSZGKGH+/5QBpgGN4O3Tu1\nak+8KpQIFKeKB86EARu73g==\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""firebase-adminsdk-fbsvc@sesw-c75c9.iam.gserviceaccount.com"",
  ""client_id"": ""106282533542840858055"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-fbsvc%40sesw-c75c9.iam.gserviceaccount.com"",
  ""universe_domain"": ""googleapis.com""
}";

    public const string MessagingURL = "https://www.googleapis.com/auth/cloud-translation";
}
