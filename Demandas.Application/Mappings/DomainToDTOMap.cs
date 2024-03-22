using AutoMapper;
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
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Demanda, DemandaDto>().ReverseMap();
            CreateMap<Empresa, EmpresaDto>().ReverseMap();

            CreateMap<Expression<Func<Empresa, bool>>, Expression<Func<EmpresaDto, bool>>>();
            CreateMap<Expression<Func<Usuario, bool>>, Expression<Func<UsuarioDto, bool>>>();
            CreateMap<Expression<Func<Cliente, bool>>, Expression<Func<ClienteDto, bool>>>();
            CreateMap<Expression<Func<Demanda, bool>>, Expression<Func<DemandaDto, bool>>>();
        }

    }
}
