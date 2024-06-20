using Demandas.Application.CQRS.Cliente.Commands;
using Demandas.Application.CQRS.Cliente.Queries;
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
    public class ClienteController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClienteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca um cliente pelo ID", Description = "Retorna os dados de um cliente específico, buscado pelo seu ID.")]
        [SwaggerResponse(200, "Cliente encontrado com sucesso", typeof(ClienteDto))]
        [SwaggerResponse(404, "Cliente não encontrado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarClientePorId(int id)
        {
            var cliente = await mediator.Send(new GetClienteByIdQuery(id));
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os clientes cadastrados", Description = "Retorna uma lista de todos os clientes cadastrados no sistema.")]
        [SwaggerResponse(200, "Lista de clientes retornada com sucesso", typeof(List<ClienteDto>))]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarClientes()
        {
            List<ClienteDto> list = await mediator.Send(new GetAllClientesQuery());
            return Ok(list);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo cliente", Description = "Cadastra um novo cliente no sistema e retorna o ID do cliente cadastrado.")]
        [SwaggerResponse(200, "Cliente cadastrado com sucesso", typeof(int))]
        [SwaggerResponse(400, "Dados inválidos fornecidos para o cadastro do cliente")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> CadastrarCliente([FromBody] ClienteDto dto)
        {
            int entityId = await mediator.Send(CreateClienteCommand.CriarPorDto(dto));
            return Ok(entityId);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de um cliente existente", Description = "Atualiza os dados de um cliente existente no sistema.")]
        [SwaggerResponse(200, "Cliente atualizado com sucesso")]
        [SwaggerResponse(400, "Dados inválidos fornecidos para a atualização do cliente")]
        [SwaggerResponse(404, "Cliente não encontrado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarCliente(int id, [FromBody] ClienteDto dto)
        {
            dto.Id = id; // Garante que o ID do DTO corresponde ao ID fornecido na URL
            var resultado = await mediator.Send(UpdateClienteCommand.CriarPorDto(dto));
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um cliente cadastrado", Description = "Deleta um cliente existente no sistema pelo seu ID.")]
        [SwaggerResponse(204, "Cliente deletado com sucesso")]
        [SwaggerResponse(404, "Cliente não encontrado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> DeletarCliente(int id)
        {
            await mediator.Send(new DeleteClienteCommand(id));
            return NoContent();
        }
    }
}