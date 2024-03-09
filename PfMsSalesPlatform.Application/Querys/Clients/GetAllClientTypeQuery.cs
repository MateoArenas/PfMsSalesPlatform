using MediatR;
using PfMsSalesPlatform.Application.DTOs;

namespace PfMsSalesPlatform.Application.Querys.Clients
{
    public record GetAllClientTypeQuery: IRequest<List<ClientTypeDto>>;
}
