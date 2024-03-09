using MediatR;
using PfMsSalesPlatform.Application.DTOs;
using PfMsSalesPlatform.Application.Querys.Clients;
using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using PfMsSalesPlatform.Infrastructure.Repositories.UnitWork;

namespace PfMsSalesPlatform.Application.Handlers.Clients
{
    public class GetOneClientTypeHandler
        : IRequestHandler<GetOneClientTypeQuery, ClientTypeDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetOneClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientTypeDto?> Handle(GetOneClientTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                ClientType? clientType = await _unitOfWork.SalesRepository<ClientType>().GetAsync(request.Id);

                return clientType == null ? null :
                    new ClientTypeDto
                    {
                        Id = clientType.Id,
                        TypeName = clientType.TypeName,
                        Discount = clientType.Discount,
                    };
            }
            catch (Exception)
            {
                return null;
            }     
        }
    }
}
