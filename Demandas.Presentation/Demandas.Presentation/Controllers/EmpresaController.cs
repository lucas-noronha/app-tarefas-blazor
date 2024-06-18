using Demandas.Application.CQRS.Empresa.Commands;
using Demandas.Application.CQRS.Empresa.Queries;
using Demandas.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> BuscarEmpresas()
        {
            List<EmpresaDto> list = await mediator.Send(new GetAllEmpresasQuery());
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] EmpresaDto dto)
        {
            int entityId = await mediator.Send(CreateEmpresaCommand.CriarPorDto(dto));
            return Ok(entityId);
        }
    }
}
