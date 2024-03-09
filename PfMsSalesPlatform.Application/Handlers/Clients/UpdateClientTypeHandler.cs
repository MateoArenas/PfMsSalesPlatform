using MediatR;
using PfMsSalesPlatform.Application.Commands.Clients;
using PfMsSalesPlatform.Application.DTOs;
using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using PfMsSalesPlatform.Infrastructure.Repositories.UnitWork;

namespace PfMsSalesPlatform.Application.Handlers.Clients
{
    public class UpdateClientTypeHandler
        : IRequestHandler<UpdateClientTypeCommand, ClientTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientTypeDto?> Handle(UpdateClientTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ClientType clientType = new ClientType
                {
                    Id = request.ClientTypeDto.Id,
                    TypeName = request.ClientTypeDto.TypeName,
                    Discount = request.ClientTypeDto.Discount,
                };

                ClientType? clientTypeResult = await _unitOfWork.SalesRepository<ClientType>().UpdateAsync(request.ClientTypeDto.Id, clientType);

                if (clientTypeResult == null)
                    return null;

                _unitOfWork.Commit();

                return new ClientTypeDto
                {
                    Id = clientType.Id,
                    TypeName = clientType.TypeName,
                    Discount = clientType.Discount,
                };
            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                return null;
            }
        }
    }
}
