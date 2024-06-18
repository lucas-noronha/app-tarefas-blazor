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
    }
}
