namespace Softwash.Infrastructure.Common.JWTConfig;
public static class JWTs
{
    public static string GenerateJwtToken(SessionDTO dto)
    {
        var claims = new[]
        {
                new Claim(SessionProperty.UserId, Convert.ToString(dto.UserId)),
                new Claim(SessionProperty.EmailOrPhoneNumber, Convert.ToString(dto.EmailOrPhoneNumber))
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

