using Demandas.Application.CQRS.Demanda.Commands;
using Demandas.Application.CQRS.Demanda.Queries;
using Demandas.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demandas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandaController : ControllerBase
    {
        private readonly IMediator mediator;

        public DemandaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca uma demanda pelo ID", Description = "Retorna os dados de uma demanda específica, buscada pelo seu ID.")]
        [SwaggerResponse(200, "Demanda encontrada com sucesso", typeof(DemandaDto))]
        [SwaggerResponse(404, "Demanda não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarDemandaPorId(int id)
        {
            var demanda = await mediator.Send(new GetDemandaByIdQuery(id));
            if (demanda == null)
            {
                return NotFound();
            }
            return Ok(demanda);
        }

        [HttpGet("por_cliente/{clienteId}")]
        [SwaggerOperation(Summary = "Busca demandas pelo ID do cliente", Description = "Retorna uma lista de demandas associadas a um cliente específico.")]
        [SwaggerResponse(200, "Lista de demandas encontrada com sucesso", typeof(List<DemandaDto>))]
        [SwaggerResponse(404, "Nenhuma demanda encontrada para o cliente especificado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarDemandasPorClienteId(int clienteId)
        {
            var demandas = await mediator.Send(new GetDemandasFromSameClienteIdQuery(clienteId));
            if (demandas == null || !demandas.Any())
            {
                return NotFound();
            }
            return Ok(demandas);
        }

        [HttpGet("por_responsavel/{responsavelId}")]
        [SwaggerOperation(Summary = "Busca demandas pelo ID do responsável", Description = "Retorna uma lista de demandas associadas a um responsável específico.")]
        [SwaggerResponse(200, "Lista de demandas encontrada com sucesso", typeof(List<DemandaDto>))]
        [SwaggerResponse(404, "Nenhuma demanda encontrada para o responsável especificado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarDemandasPorResponsavelId(int responsavelId)
        {
            var demandas = await mediator.Send(new GetDemandasFromSameResponsavelIdQuery(responsavelId));
            if (demandas == null || !demandas.Any())
            {
                return NotFound();
            }
            return Ok(demandas);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Busca todas as demandas cadastradas", Description = "Retorna uma lista de todas as demandas cadastradas no sistema.")]
        [SwaggerResponse(200, "Lista de demandas retornada com sucesso", typeof(List<DemandaDto>))]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarDemandas()
        {
            List<DemandaDto> list = await mediator.Send(new GetAllDemandasQuery());
            return Ok(list);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova demanda", Description = "Cadastra uma nova demanda no sistema e retorna o ID da demanda cadastrada.")]
        [SwaggerResponse(200, "Demanda cadastrada com sucesso", typeof(int))]
        [SwaggerResponse(400, "Dados inválidos fornecidos para o cadastro da demanda")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> CadastrarDemanda([FromBody] DemandaDto dto)
        {
            int entityId = await mediator.Send(CreateDemandaCommand.CriarPorDto(dto));
            return Ok(entityId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de uma demanda existente", Description = "Atualiza os dados de uma demanda existente no sistema.")]
        [SwaggerResponse(200, "Demanda atualizada com sucesso")]
        [SwaggerResponse(400, "Dados inválidos fornecidos para a atualização da demanda")]
        [SwaggerResponse(404, "Demanda não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarDemanda(int id, [FromBody] DemandaDto dto)
        {
            dto.Id = id; // Garante que o ID do DTO corresponde ao ID fornecido na URL
            var resultado = await mediator.Send(UpdateDemandaCommand.CriarPorDto(dto));
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta uma demanda cadastrada", Description = "Deleta uma demanda existente no sistema pelo seu ID.")]
        [SwaggerResponse(204, "Demanda deletada com sucesso")]
        [SwaggerResponse(404, "Demanda não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> DeletarDemanda(int id)
        {
            await mediator.Send(new DeleteDemandaCommand(id));
            return NoContent();
        }
    }
}
