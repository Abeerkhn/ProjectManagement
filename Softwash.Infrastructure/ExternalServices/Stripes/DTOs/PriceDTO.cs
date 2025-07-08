namespace Softwash.Infrastructure.ExternalServices.Stripes.DTOs;

public class PriceDTO
{
    public string ProductId { get; set; }
    public decimal AmountDecimal { get; set; }
    public string Currency { get; set; }
    public string Interval { get; set; }
}
