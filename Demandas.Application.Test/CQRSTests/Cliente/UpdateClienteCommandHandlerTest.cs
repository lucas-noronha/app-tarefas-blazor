using AutoMapper;
using Demandas.Application.CQRS.Cliente.Commands.Handlers;
using Demandas.Application.CQRS.Cliente.Commands;
using Demandas.Application.DTOs;
using Demandas.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demandas.Application.Services;

namespace Demandas.Application.Test.CQRSTests.Cliente
{
    public class UpdateClienteCommandHandlerTest
    {
        private readonly Mock<IClienteRepository> _mockClienteRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ClienteService _clienteService;
        public UpdateClienteCommandHandlerTest()
        {
            _mockClienteRepository = new Mock<IClienteRepository>();
            _mockMapper = new Mock<IMapper>();
            _clienteService = new ClienteService(_mockMapper.Object, _mockClienteRepository.Object);
        }

        [Fact]
        public async Task Handle_GivenValidCommand_ShouldUpdateCliente()
        {
            // Arrange
            ClienteDto clienteDto = new ClienteDto
            {
                Nome = "Cliente Numero 2",
                Contato = "email@email",
                EmpresaId = 2,
                UsuarioUltimaEdicaoId = 2
            };
            var command = new UpdateClienteCommand(clienteDto);
            var cliente = new Domain.Entities.Cliente("Cliente Numero 1", "email@email", 1, 1);
            _mockMapper.Setup(m => m.Map<Domain.Entities.Cliente>(It.IsAny<ClienteDto>())).Returns(cliente);
            _mockMapper.Setup(m => m.Map<ClienteDto>(It.IsAny<Domain.Entities.Cliente>())).Returns(clienteDto);
            _mockClienteRepository.Setup(r => r.AtualizarAsync(It.IsAny<Domain.Entities.Cliente>())).ReturnsAsync(cliente);

            var handler = new UpdateClienteCommandHandler(_clienteService);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            _mockClienteRepository.Verify(r => r.AtualizarAsync(It.IsAny<Domain.Entities.Cliente>()), Times.Once);
        }
    }
}
