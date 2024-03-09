using Moq;
using PfMsSalesPlatform.Application.Commands.Clients;
using PfMsSalesPlatform.Application.DTOs;
using PfMsSalesPlatform.Application.Handlers.Clients;
using PfMsSalesPlatform.Domain.Aggregates.Clients.Models;
using PfMsSalesPlatform.Infrastructure.Repositories;
using PfMsSalesPlatform.Infrastructure.Repositories.UnitWork;

namespace PfMsSalesPlatform.Test.ApplicationTests.Handler.Clients
{
    public class CreateClientTypeCommandTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly Mock<ISalesRepository<ClientType>> _clientTypeRepository;

        public CreateClientTypeCommandTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _clientTypeRepository = new Mock<ISalesRepository<ClientType>>();
        }

        [Fact]
        public void Handler_InputCreateClientTypeCommandNotvalirObj_ResturnNull() 
        {
            //Arrage
            ClientTypeDto clientTypeDto = new();
            CreateClientTypeCommand createClientTypeCommand  = new(clientTypeDto);
            ClientType clientType = null;
            Task<ClientType> clientTypeResult = Task.FromResult(clientType);
            _clientTypeRepository.Setup(x => x.InsertAsync(It.IsAny<ClientType>())).Returns(clientTypeResult);
            _unitOfWork.Setup(x => x.SalesRepository<ClientType>().InsertAsync(It.IsAny<ClientType>())).Returns(clientTypeResult);
            CreateClientTypeHandler createClientTypeHandler = new(_unitOfWork.Object);
            //Act
            var Result = createClientTypeHandler.Handle(createClientTypeCommand, CancellationToken.None);
            //Asserts
            Assert.Null(Result.Result);
        }

        [Fact]
        public void Handler_InputCreateClientTypeCommandvalitObj_ResturnObject()
        {
            //Arrage
            ClientTypeDto clientTypeDto = new();
            CreateClientTypeCommand createClientTypeCommand = new(clientTypeDto);
            ClientType clientType = new();
            Task<ClientType> clientTypeResult = Task.FromResult(clientType);
            _clientTypeRepository.Setup(x => x.InsertAsync(It.IsAny<ClientType>())).Returns(clientTypeResult);
            _unitOfWork.Setup(x => x.SalesRepository<ClientType>().InsertAsync(It.IsAny<ClientType>())).Returns(clientTypeResult);
            CreateClientTypeHandler createClientTypeHandler = new(_unitOfWork.Object);
            //Act
            var Result = createClientTypeHandler.Handle(createClientTypeCommand, CancellationToken.None);
            //Asserts
            Assert.NotNull(Result.Result);
        }
    }
}
