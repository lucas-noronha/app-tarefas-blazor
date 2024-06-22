using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Application.Services;
using Demandas.Domain.Entities;
using Demandas.Domain.Enums;
using Demandas.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Test.ServiceTests
{
    public class DemandaServiceTest
    {

        private readonly DemandaService _demandaService;
        private readonly Mock<IDemandaRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        public DemandaServiceTest()
        {

            _mockRepository = new Mock<IDemandaRepository>();
            _mockMapper = new Mock<IMapper>();
            _demandaService = new DemandaService(_mockMapper.Object, _mockRepository.Object);
        }

        [Fact]
        [Trait("Demanda", "Buscar demanda por ID")]
        public async Task BuscarPorId_DeveRetornarDemanda_QuandoDemandaExiste()
        {
            // Arrange
            var demanda = new Demanda("Demanda Titulo 1", "descricao1", EnumStatusDemanda.Adicionada, EnumTipoDemanda.NovoRecurso, 1, false, true, 1, 1);
            var demandaDto = new DemandaDto()
            {
                ClienteId = demanda.ClienteId,
                Descricao = demanda.Descricao,
                Id = demanda.Id,
                Titulo = demanda.Titulo,
                Status = demanda.Status,
                TipoDemanda = demanda.TipoDemanda,
                UsuarioUltimaEdicaoId = demanda.UsuarioUltimaEdicaoId,
                UsuarioResponsavelId = demanda.UsuarioResponsavelId,
                Urgente = demanda.Urgente,
                DataFinalizacao = demanda.DataFinalizacao,
                EmpresaId = demanda.EmpresaId,
                Importante = demanda.Importante
            };

            _mockRepository.Setup(repo => repo.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(demanda);
            _mockMapper.Setup(mapper => mapper.Map<DemandaDto>(demanda)).Returns(demandaDto);


            // Act
            var result = await _demandaService.BuscarPorIdAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(demanda.Titulo, result.Titulo);
        }

        [Fact]
        [Trait("Demanda", "Testando buscar todas as demandas")]
        public async Task BuscarTodos_DeveRetornarTodasDemandas()
        {
            // Arrange
            var demandas = new List<Demanda>
            {
                new Demanda("Demanda Titulo 1", "descricao1", EnumStatusDemanda.Adicionada, EnumTipoDemanda.ModificacaoRecurso, 1, true, true, 1, 1),
                new Demanda("Demanda Titulo 2", "descricao2", EnumStatusDemanda.Adicionada, EnumTipoDemanda.NovoRecurso, 2, false, true, 1, 1),
            };

            List<DemandaDto> demandaDtos = demandas.Select(d => new DemandaDto
            {
                ClienteId = d.ClienteId,
                Descricao = d.Descricao,
                Id = d.Id,
                Titulo = d.Titulo,
                Status = d.Status,
                TipoDemanda = d.TipoDemanda,
                UsuarioUltimaEdicaoId = d.UsuarioUltimaEdicaoId,
                UsuarioResponsavelId = d.UsuarioResponsavelId,
                Urgente = d.Urgente,
                DataFinalizacao = d.DataFinalizacao,
                EmpresaId = d.EmpresaId,
                Importante = d.Importante
            }).ToList();

            _mockRepository.Setup(repo => repo.ListarQueryAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Demanda, bool>>>())).ReturnsAsync(demandas);
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<DemandaDto>>(It.IsAny<IEnumerable<Demanda>>())).Returns(demandaDtos);


            // Act
            var result = await _demandaService.BuscarListaAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(demandas.Count, result.Count());
        }

        [Fact]
        [Trait("Demanda", "Testando adicionar demanda")]
        public async Task Adicionar_DeveAdicionarDemanda()
        {
            // Arrange
            DemandaDto demandaDto = new DemandaDto()
            {
                ClienteId = 1,
                Descricao = "descricao1",
                EmpresaId = 1,
                Importante = true,
                Status = EnumStatusDemanda.Adicionada,
                TipoDemanda = EnumTipoDemanda.ModificacaoRecurso,
                Titulo = "Demanda Titulo 1",
                Urgente = true,
                UsuarioResponsavelId = 1,
                UsuarioUltimaEdicaoId = 1,
            };

            Demanda demanda = new Demanda(demandaDto.Titulo, demandaDto.Descricao, demandaDto.Status, demandaDto.TipoDemanda, demandaDto.ClienteId, demandaDto.Urgente, demandaDto.Importante, demandaDto.UsuarioResponsavelId, demandaDto.UsuarioUltimaEdicaoId);
            _mockMapper.Setup(mapper => mapper.Map<Demanda>(It.IsAny<DemandaDto>())).Returns(demanda);
            _mockMapper.Setup(mapper => mapper.Map<DemandaDto>(It.IsAny<Demanda>())).Returns(demandaDto);
            _mockRepository.Setup(repo => repo.SalvarAsync(It.IsAny<Demanda>())).ReturnsAsync(demanda);

            // Act
            var result = await _demandaService.Adicionar(demandaDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(demandaDto.Titulo, result.Titulo);
            _mockRepository.Verify(repo => repo.SalvarAsync(It.IsAny<Demanda>()), Times.Once);
        }

        [Fact]
        [Trait("Demanda", "Testando atualizar demanda")]
        public async Task Atualizar_DeveAtualizarDemanda()
        {
            // Arrange
            DemandaDto demandaDto = new DemandaDto()
            {
                ClienteId = 1,
                Descricao = "descricao1",
                EmpresaId = 1,
                Importante = true,
                Status = EnumStatusDemanda.Adicionada,
                TipoDemanda = EnumTipoDemanda.ModificacaoRecurso,
                Titulo = "Demanda Titulo 1",
                Urgente = true,
                UsuarioResponsavelId = 1,
                UsuarioUltimaEdicaoId = 1,
            };
            Demanda demanda = new Demanda(demandaDto.Titulo, demandaDto.Descricao, demandaDto.Status, demandaDto.TipoDemanda, demandaDto.ClienteId, demandaDto.Urgente, demandaDto.Importante, demandaDto.UsuarioResponsavelId, demandaDto.UsuarioUltimaEdicaoId);
            _mockMapper.Setup(mapper => mapper.Map<Demanda>(It.IsAny<DemandaDto>())).Returns(demanda);
            _mockMapper.Setup(mapper => mapper.Map<DemandaDto>(It.IsAny<Demanda>())).Returns(demandaDto);
            _mockRepository.Setup(repo => repo.AtualizarAsync(It.IsAny<Demanda>())).ReturnsAsync(demanda);

            demandaDto.Titulo = "Novo Titulo Para Demanda";
            // Act
            var result = await _demandaService.Atualizar(demandaDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(demandaDto.Titulo, result.Titulo);
            _mockRepository.Verify(repo => repo.AtualizarAsync(It.IsAny<Demanda>()), Times.Once);
        }

        [Fact]
        [Trait("Demanda", "Tesando remover demanda.")]
        public async Task Remover_DeveRemoverDemanda()
        {
            // Arrange
            DemandaDto demandaDto = new DemandaDto()
            {
                ClienteId = 1,
                Descricao = "descricao1",
                EmpresaId = 1,
                Importante = true,
                Status = EnumStatusDemanda.Adicionada,
                TipoDemanda = EnumTipoDemanda.ModificacaoRecurso,
                Titulo = "Demanda Titulo 1",
                Urgente = true,
                UsuarioResponsavelId = 1,
                UsuarioUltimaEdicaoId = 1,
            };
            Demanda demanda = new Demanda(demandaDto.Titulo, demandaDto.Descricao, demandaDto.Status, demandaDto.TipoDemanda, demandaDto.ClienteId, demandaDto.Urgente, demandaDto.Importante, demandaDto.UsuarioResponsavelId, demandaDto.UsuarioUltimaEdicaoId);
            _mockMapper.Setup(mapper => mapper.Map<Demanda>(It.IsAny<DemandaDto>())).Returns(demanda);
            _mockMapper.Setup(mapper => mapper.Map<DemandaDto>(It.IsAny<Demanda>())).Returns(demandaDto);
            _mockRepository.Setup(repo => repo.Deletar(It.IsAny<int>()));

            // Act
            await _demandaService.Remover(1);

            //Assert
            _mockRepository.Verify(repo => repo.Deletar(It.IsAny<int>()), Times.Once);

        }
    }
}
