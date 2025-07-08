namespace Softwash.Infrastructure.ExternalServices.SMS;

public static class TwilioSms
{
    public static bool SendSMS(string contactNumber, string otp)
    {
        var accountId = Twillio.AccountSID;
        var token = Twillio.AccountToken;
        var number = Twillio.Number;

        TwilioClient.Init(accountId, token);
        var receiver = new PhoneNumber(contactNumber);
        var sender = new PhoneNumber(number);

        try
        {
            var message = MessageResource.CreateAsync(
                to: receiver,
                from: sender,
                body: $"Here is the OTP for verification of your number: {otp}"
            );

            // Check if the message was sent successfully
            Console.WriteLine($"{message.Status},{message.Result.ErrorCode},{message.Result.Body}");
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            Console.WriteLine($"Failed to send SMS: {ex.Message}");
            return false;
        }
    }
    public static bool SendInvitation(string contactNumber, string invitationLink)
    {
        var accountId = Twillio.AccountSID;
        var token = Twillio.AccountToken;
        var number = Twillio.Number;

        TwilioClient.Init(accountId, token);
        var receiver = new PhoneNumber(contactNumber);
        var sender = new PhoneNumber(number);

        try
        {
            var message = MessageResource.CreateAsync(
                to: receiver,
                from: sender,
                body: $"Here is the Link of Softwash App : {invitationLink}"
            );

            // Check if the message was sent successfully
            Console.WriteLine($"{message.Status},{message.Result.ErrorCode},{message.Result.Body}");
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            Console.WriteLine($"Failed to send SMS: {ex.Message}");
            return false;
        }
    }
}
