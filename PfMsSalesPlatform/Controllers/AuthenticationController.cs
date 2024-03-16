using MediatR;
using Microsoft.AspNetCore.Mvc;
using PfMsSalesPlatform.Application.Commands.Auth;

namespace PfMsSalesPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediatoR;
        private readonly string _secretKey;
        public AuthenticationController(IMediator mediatoR, IConfiguration configuration)
        {
            _mediatoR = mediatoR;
            _secretKey = configuration.GetSection("SettingJWT:SecretKey").ToString();
        }

        [HttpPost("GenerateToken")]
        public async Task<ActionResult<string>> GenerateToken(GenerateTokenUserCommand generateTokenUser) 
        {
            generateTokenUser.UserDto.key = _secretKey;
            string token = await _mediatoR.Send(generateTokenUser);
            if (token == null)
                return NoContent();

            return Ok(token);
        }
    }
}
