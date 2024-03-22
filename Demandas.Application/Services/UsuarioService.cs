using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Services
{
    public class UsuarioService : ServiceBase<UsuarioDto, Usuario>, IUsuarioService
    {
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository) : base(mapper, usuarioRepository)
        {}
    }
}
