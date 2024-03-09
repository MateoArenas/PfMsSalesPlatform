using MediatR;
using PfMsSalesPlatform.Application.DTOs;

namespace PfMsSalesPlatform.Application.Querys.Clients
{
    public record GetOneClientTypeQuery(int Id): IRequest<ClientTypeDto>;
}
