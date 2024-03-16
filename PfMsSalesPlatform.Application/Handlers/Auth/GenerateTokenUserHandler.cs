using MediatR;
using Microsoft.IdentityModel.Tokens;
using PfMsSalesPlatform.Application.Commands.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PfMsSalesPlatform.Application.Handlers.Auth
{
    public class GenerateTokenUserHandler : IRequestHandler<GenerateTokenUserCommand, string>
    {
        public Task<string> Handle(GenerateTokenUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(request.UserDto.key);
                ClaimsIdentity claims = new();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.UserDto.RegisterUser));

                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor 
                { 
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                JwtSecurityTokenHandler tokenHandler = new();
                SecurityToken tokenConfig = tokenHandler.CreateToken(descriptor);

                return Task.FromResult<string>(tokenHandler.WriteToken(tokenConfig));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar el token --> {ex.Message}");
            }
        }
    }
}
