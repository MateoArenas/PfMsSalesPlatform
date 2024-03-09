using MediatR;
using PfMsSalesPlatform.Application.DTOs;

namespace PfMsSalesPlatform.Application.Commands.Clients
{
    public record CreateClientTypeCommand(ClientTypeDto ClientTypeDto) : IRequest<ClientTypeDto>;
}
