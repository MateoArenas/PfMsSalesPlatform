using MediatR;
using PfMsSalesPlatform.Application.DTOs;

namespace PfMsSalesPlatform.Application.Commands.Clients
{
    public record UpdateClientTypeCommand(ClientTypeDto ClientTypeDto): IRequest<ClientTypeDto>;
}
