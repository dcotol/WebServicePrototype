using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Security.Cryptography;

namespace WCFServiceTest
{
  public class JwtTokenIssuer
  {
    public static string GenerateJwtToken(string userName)
    {

      // More Security
      //var key = new byte[32]; // 256 bits
      //using (var generator = RandomNumberGenerator.Create())
      //{
      //  generator.GetBytes(key);
      //}
      //var secretKey = Convert.ToBase64String(key);
      //var symmetricSecurityKey = new SymmetricSecurityKey(key);


      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("FacturacionElectronicaInnova&Factured2024@!"));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
          {
                new Claim(ClaimTypes.Name, userName)
          }),
        Expires = DateTime.UtcNow.AddHours(24),
        SigningCredentials = credentials,
        Audience = "Factured",
        Issuer = "Innova"
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }

}