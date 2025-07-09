namespace Softwash.Infrastructure.Common;

public static class GetClaims
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static void Initialize(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public static ClaimsPrincipal GetUserPrincipal()
    {
        var context = _httpContextAccessor.HttpContext;
        if (context == null || !context.User.Identity.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("Unauthorized access: no valid token provided.");
        }
        return context.User;
    }

    public static long GetUserId()
    {
        var user = GetUserPrincipal();
        var claim = user.Claims.FirstOrDefault(c => c.Type == SessionProperty.UserId);
        return claim != null ? Convert.ToInt64(claim.Value) : throw new UnauthorizedAccessException("User ID claim not found.");
    }

    public static string GetUserEmailOrPhoneNumber()
    {
        var user = GetUserPrincipal();
        var claim = user.Claims.FirstOrDefault(c => c.Type == SessionProperty.EmailOrPhoneNumber);
        return claim?.Value ?? throw new UnauthorizedAccessException("Email or phone number claim not found.");
    }
}
