using Demandas.Application.CQRS.Usuario.Commands;
using Demandas.Application.CQRS.Usuario.Queries;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Busca todos os usuários cadastrados.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os usuários cadastrados", Description = "Retorna uma lista de todos os usuários cadastrados no sistema.")]
        [SwaggerResponse(200, "Lista de usuários retornada com sucesso", typeof(List<UsuarioDto>))]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> BuscarUsuarios()
        {
            List<UsuarioDto> list = await mediator.Send(new GetAllUsuariosQuery());
            return Ok(list);
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="dto">Dados do usuário a ser cadastrado.</param>
        /// <returns>ID do usuário cadastrado.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo usuário", Description = "Cadastra um novo usuário no sistema e retorna o ID do usuário cadastrado.")]
        [SwaggerResponse(200, "Usuário cadastrado com sucesso", typeof(int))]
        [SwaggerResponse(400, "Dados inválidos fornecidos para o cadastro do usuário")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioDto dto)
        {
            int entityId = await mediator.Send(CreateUsuarioCommand.CriarPorDto(dto));
            return Ok(entityId);
        }

        [HttpPost("alterar_senha")]
        [SwaggerOperation(Summary = "Altera a senha de um usuário", Description = "Altera a senha de um usuário existente no sistema.")]
        [SwaggerResponse(200, "Senha alterada com sucesso")]
        [SwaggerResponse(400, "Dados inválidos fornecidos para a alteração da senha do usuário")]
        [SwaggerResponse(404, "Usuário não encontrado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> AlterarSenha([FromBody] UsuarioAlterarSenhaDTO dto)
        {
            await mediator.Send(ChangeUsuarioPasswordCommand.CriarPorDto(dto));
            return Ok();
        }

        /// <summary>
        /// Atualiza os dados de um usuário.
        /// </summary>
        /// <param name="dto">Dados atualizados do usuário.</param>
        /// <returns>Dados do usuário atualizado.</returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Atualiza os dados de um usuário", Description = "Atualiza os dados de um usuário existente no sistema.")]
        [SwaggerResponse(200, "Usuário atualizado com sucesso", typeof(UsuarioDto))]
        [SwaggerResponse(400, "Dados inválidos fornecidos para a atualização do usuário")]
        [SwaggerResponse(404, "Usuário não encontrado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioDto dto)
        {
            UsuarioDto updated = await mediator.Send(UpdateUsuarioCommand.CriarPorDto(dto));
            return Ok(updated);
        }

        /// <summary>
        /// Deleta um usuário cadastrado.
        /// </summary>
        /// <param name="id">ID do usuário a ser deletado.</param>
        /// <returns>Confirmação de que o usuário foi deletado.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um usuário cadastrado", Description = "Deleta um usuário existente no sistema pelo seu ID.")]
        [SwaggerResponse(200, "Usuário deletado com sucesso")]
        [SwaggerResponse(404, "Usuário não encontrado")]
        [SwaggerResponse(500, "Erro interno no servidor")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            await mediator.Send(DeleteUsuarioCommand.CriarPorId(id));
            return Ok();
        }
    }
}
