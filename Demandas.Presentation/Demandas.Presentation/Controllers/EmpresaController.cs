using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demandas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            this.empresaService = empresaService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarEmpresas()
        {
            var lista = await empresaService.BuscarListaAsync();
            return Ok(lista);
        }

        [HttpGet("teste")]
        public async Task<IActionResult> BuscarEmpresasFiltro()
        {
            var lista = await empresaService.BuscarListaComQueryAsync(x => x.Id == 1);
            return Ok(lista);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] EmpresaDto dto)
        {
            var empresa = await empresaService.Adicionar(dto);

            return Ok(empresa);
        }
    }
}
