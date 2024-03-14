using MediatR;
using PfMsSalesPlatform.Application.Commands.Clients;
using PfMsSalesPlatform.Application.DTOs;
using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using PfMsSalesPlatform.Infrastructure.Repositories.UnitWork;

namespace PfMsSalesPlatform.Application.Handlers.Clients
{
    public class CreateClientTypeHandler : IRequestHandler<CreateClientTypeCommand, ClientTypeDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClientTypeDto?> Handle(CreateClientTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                ClientType clientType = new ClientType
                {
                    Id = 0,
                    TypeName = request.ClientTypeDto.TypeName,
                    Discount = request.ClientTypeDto.Discount,
                };

                ClientType? result = await _unitOfWork.SalesRepository<ClientType>().InsertAsync(clientType);

                if (result == null)
                    return null;

                _unitOfWork.Commit();

                return new ClientTypeDto
                {
                    Id = result.Id,
                    TypeName = result.TypeName,
                    Discount = result.Discount,
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                throw new Exception($"Error al guardar el tipo cliente. Error: {ex}");
            }
        }
    }
}
