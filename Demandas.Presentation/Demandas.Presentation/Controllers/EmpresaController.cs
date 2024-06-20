using Demandas.Application.CQRS.Empresa.Commands;
using Demandas.Application.CQRS.Empresa.Queries;
using Demandas.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Demandas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator mediator;

        public EmpresaController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        /// <summary>
        /// Busca uma empresa pelo ID.
        /// </summary>
        /// <param name="id">ID da empresa a ser buscada.</param>
        /// <returns>Dados da empresa buscada.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Busca uma empresa pelo ID", Description = "Retorna os dados de uma empresa específica, buscada pelo seu ID.")]
        [SwaggerResponse(200, "Empresa encontrada com sucesso", typeof(EmpresaDto))]
        [SwaggerResponse(404, "Empresa não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarEmpresaPorId(int id)
        {
            var empresa = await mediator.Send(new GetEmpresaByIdQuery(id));
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        /// <summary>
        /// Busca todas as empresas cadastradas.
        /// </summary>
        /// <returns>Uma lista de empresas.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Busca todas as empresas cadastradas", Description = "Retorna uma lista de todas as empresas cadastradas no sistema.")]
        [SwaggerResponse(200, "Lista de empresas retornada com sucesso", typeof(List<EmpresaDto>))]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarEmpresas()
        {
            List<EmpresaDto> list = await mediator.Send(new GetAllEmpresasQuery());
            return Ok(list);
        }


        /// <summary>
        /// Cadastra uma nova empresa.
        /// </summary>
        /// <param name="dto">Dados da empresa a ser cadastrada.</param>
        /// <returns>ID da empresa cadastrada.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova empresa", Description = "Cadastra uma nova empresa no sistema e retorna o ID da empresa cadastrada.")]
        [SwaggerResponse(200, "Empresa cadastrada com sucesso", typeof(int))]
        [SwaggerResponse(400, "Dados inválidos fornecidos para o cadastro da empresa")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] EmpresaDto dto)
        {
            int entityId = await mediator.Send(CreateEmpresaCommand.CriarPorDto(dto));
            return Ok(entityId);
        }

        /// <summary>
        /// Atualiza os dados de uma empresa existente.
        /// </summary>
        /// <param name="id">ID da empresa a ser atualizada.</param>
        /// <param name="dto">Dados atualizados da empresa.</param>
        /// <returns>Resultado da operação de atualização.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza os dados de uma empresa existente", Description = "Atualiza os dados de uma empresa existente no sistema.")]
        [SwaggerResponse(200, "Empresa atualizada com sucesso")]
        [SwaggerResponse(400, "Dados inválidos fornecidos para a atualização da empresa")]
        [SwaggerResponse(404, "Empresa não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarEmpresa(int id, [FromBody] EmpresaDto dto)
        {
            dto.Id = id; // Garante que o ID do DTO corresponde ao ID fornecido na URL
            var resultado = await mediator.Send(UpdateEmpresaCommand.CriarPorDto(dto));
            return Ok(resultado);
        }

        /// <summary>
        /// Deleta uma empresa cadastrada.
        /// </summary>
        /// <param name="id">ID da empresa a ser deletada.</param>
        /// <returns>Confirmação da operação de deleção.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta uma empresa cadastrada", Description = "Deleta uma empresa existente no sistema pelo seu ID.")]
        [SwaggerResponse(204, "Empresa deletada com sucesso")]
        [SwaggerResponse(404, "Empresa não encontrada")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> DeletarEmpresa(int id)
        {
            await mediator.Send(new DeleteEmpresaCommand(id));
            
            return NoContent();
        }
    }
}
