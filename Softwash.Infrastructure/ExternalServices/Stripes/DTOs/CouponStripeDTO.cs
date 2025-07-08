namespace Softwash.Infrastructure.ExternalServices.Stripes.DTOs;

public class CouponStripeDTO
{
    public string Id { get; set; }
    public int? Percentage { get; set; }
    public int? Amount { get; set; }
    public long? DurationInMonths { get; set; }
}
