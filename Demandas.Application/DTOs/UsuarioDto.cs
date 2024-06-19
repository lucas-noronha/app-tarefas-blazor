using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.DTOs
{
    /// <summary>
    /// Representa um usuário no sistema.
    /// </summary>
    public class UsuarioDto
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Login de acesso do usuário.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Senha de acesso do usuário. Deve ser armazenada de forma segura.
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Endereço de email do usuário. Pode ser nulo.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Indica se o usuário tem permissões de administrador.
        /// </summary>
        public bool Administrador { get; set; }

        /// <summary>
        /// Indica se o usuário é um desenvolvedor.
        /// </summary>
        public bool Desenvolvedor { get; set; }

        /// <summary>
        /// Identificador da empresa à qual o usuário está associado.
        /// </summary>
        public int EmpresaId { get; set; }

        /// <summary>
        /// Identificador do usuário que realizou a última edição neste registro de usuário.
        /// </summary>
        public int UsuarioUltimaEdicaoId { get; set; }
    }
}
