using Demandas.Application.CQRS.Cliente.Commands.Handlers;
using Demandas.Application.CQRS.Cliente.Commands;
using Demandas.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demandas.Application.Services;
using AutoMapper;

namespace Demandas.Application.Test.CQRSTests.Cliente
{
    public  class DeleteClienteCommandHandlerTest
    {
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly ClienteService _clienteService;
        public DeleteClienteCommandHandlerTest()
        {
            _mockClienteRepository = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(new Mock<IMapper>().Object, _mockClienteRepository.Object);
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldDeleteCliente()
        {
            // Arrange
            var command = new DeleteClienteCommand(1);
            _mockClienteRepository.Setup(r => r.Deletar(It.IsAny<int>()));

            var handler = new DeleteClienteCommandHandler(_clienteService);

            // Act
            await handler.Handle(command, new CancellationToken());

            // Assert
            _mockClienteRepository.Verify(r => r.Deletar(It.IsAny<int>()), Times.Once);
        }
    }
}
