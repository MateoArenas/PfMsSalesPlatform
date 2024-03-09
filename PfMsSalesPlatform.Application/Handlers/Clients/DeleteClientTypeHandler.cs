using MediatR;
using PfMsSalesPlatform.Application.Commands.Clients;
using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using PfMsSalesPlatform.Infrastructure.Repositories.UnitWork;

namespace PfMsSalesPlatform.Application.Handlers.Clients
{
    public class DeleteClientTypeHandler
        : IRequestHandler<DeleteClientTypeCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteClientTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteClientTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _unitOfWork.SalesRepository<ClientType>().DeleteAsync(request.Id);

                if (!result)
                    return result;

                _unitOfWork.Commit();

                return result;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return false;
            }
        }
    }
}
