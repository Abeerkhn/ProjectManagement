namespace Softwash.Infrastructure.ExternalServices.Firebase;

public static class FirebaseAdminInitializer
{
    public static void Initialize()
    {
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromJson(Softwash.Infrastructure.Common.Firebase.json)
        });
    }
}
