using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading;
using System.IdentityModel.Selectors;

namespace WCFServiceTest
{
  public class JwtTokenValidator : ServiceAuthorizationManager
  {
    protected override bool CheckAccessCore(OperationContext operationContext)
    {
      var request = operationContext.RequestContext.RequestMessage;
      var headers = request.Headers;
      var authorizationHeader = headers.GetHeader<string>("Authorization", "http://schemas.microsoft.com/ws/2006/05/security");

      if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
      {
        return false;
      }

      var token = authorizationHeader.Substring("Bearer ".Length).Trim();

      // Validate the token
      //if (ValidateToken(token))
      //{
      //  return true;
      //}

      //return false;

      var validationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = "Innova",
        ValidateAudience = true,
        ValidAudience = "Factured",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("FacturacionElectronicaInnova&Factured2024@!")),
        ValidateLifetime = true
      };

      try
      {
        SecurityToken validatedToken;
        var handler = new JwtSecurityTokenHandler();
        var principal = handler.ValidateToken(token, validationParameters, out validatedToken);

        operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = principal;
        return true;
      }
      catch (Exception)
      {
        return false;
      }


    }

    //private bool ValidateToken(string token)
    //{
    //  var tokenHandler = new JwtSecurityTokenHandler();
    //  var validationParameters = new TokenValidationParameters
    //  {
    //    ValidateIssuer = true,
    //    ValidateAudience = true,
    //    ValidateIssuerSigningKey = true,
    //    ValidIssuer = "yourIssuer",
    //    ValidAudience = "yourAudience",
    //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourSecretKey"))
    //  };

    //  try
    //  {
    //    var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);
    //    // Attach the principal to the current thread
    //    Thread.CurrentPrincipal = principal;
    //    return true;
    //  }
    //  catch
    //  {
    //    return false;
    //  }
    //}
  }

  public class CustomUserNamePasswordValidator : UserNamePasswordValidator
  {
    public override void Validate(string userName, string password)
    {
      // Custom validation logic
      if (userName != "dcotolara@gmail.com" || password != "Admin123@")
      {
        throw new FaultException("Unknown Username or Incorrect Password");
      }
      else
      {
        var token = JwtTokenIssuer.GenerateJwtToken("dcotolara@gmail.com");
      }
    }
  }

}