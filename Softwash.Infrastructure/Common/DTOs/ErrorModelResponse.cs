namespace Softwash.Infrastructure.Common.DTOs;

public class ErrorModel
{
    public string? FieldName { get; set; }
    public string? Message { get; set; }
}

public class ErrorModelResponse
{
    public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
}
