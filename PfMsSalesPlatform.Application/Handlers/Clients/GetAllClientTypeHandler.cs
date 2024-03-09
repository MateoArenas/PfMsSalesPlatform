using MediatR;
using PfMsSalesPlatform.Application.DTOs;
using PfMsSalesPlatform.Application.Querys.Clients;
using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using PfMsSalesPlatform.Infrastructure.Repositories.UnitWork;

namespace PfMsSalesPlatform.Application.Handlers.Clients
{
    public class GetAllClientTypeHandler
        : IRequestHandler<GetAllClientTypeQuery, List<ClientTypeDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ClientTypeDto>> Handle(GetAllClientTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<ClientType> clientList = await _unitOfWork.SalesRepository<ClientType>().GetAll();

                return clientList.Select(x => new ClientTypeDto
                {
                    Discount = x.Discount,
                    Id = x.Id,
                    TypeName = x.TypeName,
                }).ToList();
            }
            catch (Exception)
            {
                return new List<ClientTypeDto>();
            }
        }
    }
}
