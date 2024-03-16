using MediatR;
using PfMsSalesPlatform.Application.DTOs;

namespace PfMsSalesPlatform.Application.Commands.Auth
{
    public record GenerateTokenUserCommand(UserDto UserDto): IRequest<string>;
}
