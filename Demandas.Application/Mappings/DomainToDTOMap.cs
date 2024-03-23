using AutoMapper;
using AutoMapper.Configuration;
using Demandas.Application.DTOs;
using Demandas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Mappings
{
    public class DomainToDTOMap : Profile
    {
        public DomainToDTOMap()
        {
            
            CreateMap<Cliente, ClienteDto>()
                .ReverseMap()
                .ConstructUsing(x => new Cliente(x.Nome, x.Contato, x.EmpresaId, x.UsuarioUltimaEdicaoId));
            CreateMap<Usuario, UsuarioDto>().ReverseMap().ConstructUsing(x => new Usuario(x.Nome, x.Login, x.Senha, x.Email, x.Desenvolvedor, x.Administrador, x.UsuarioUltimaEdicaoId, x.EmpresaId));
            CreateMap<Demanda, DemandaDto>().ReverseMap().ConstructUsing(x => new Demanda(x.Titulo, x.Descricao,x.Status, x.TipoDemanda, x.ClienteId, x.Urgente, x.Importante, x.UsuarioUltimaEdicaoId, x.EmpresaId));
            CreateMap<Empresa, EmpresaDto>().ReverseMap().ConstructUsing(x => new Empresa(x.Nome, x.Logo, x.UsuarioUltimaEdicaoId));

            CreateMap<Expression<Func<Empresa, bool>>, Expression<Func<EmpresaDto, bool>>>();
            CreateMap<Expression<Func<Usuario, bool>>, Expression<Func<UsuarioDto, bool>>>();
            CreateMap<Expression<Func<Cliente, bool>>, Expression<Func<ClienteDto, bool>>>();
            CreateMap<Expression<Func<Demanda, bool>>, Expression<Func<DemandaDto, bool>>>();

            
        }

    }
}
