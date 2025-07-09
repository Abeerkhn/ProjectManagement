namespace Softwash.Infrastructure.ExternalServices.Email;

public static class EmailSender
{
    public static Task SendingPasswordToEmail(EmailDTO dto)
    {
        var res = SendAsync(dto);
        return res;
    }

    public static Task SendingOTP(EmailDTO dto)
    {
        dto.Message = "OTP : " + dto.Message;
        var res = SendAsync(dto);
        return res;
    }
    public static Task SendAsync(EmailDTO dto)
    {
        var client = new SendGridClient(SendGridKey.Key);
        var message = new SendGridMessage()
        {
            From = new EmailAddress(SendGridKey.Email, SendGridKey.Username),
            Subject = "OTP from VINCIIO",
            PlainTextContent = dto.Message,
            HtmlContent = dto.Message,
        };

        message.AddTo(new EmailAddress { Email = dto.Email });

        message.SetClickTracking(false, false);
        return client.SendEmailAsync(message);
    }

    public static int generateOTP()
    {
        var rnd = new Random();
        return rnd.Next(100000, 1000000);

    }
}
