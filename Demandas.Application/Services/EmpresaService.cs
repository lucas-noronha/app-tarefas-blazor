using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;
        public EmpresaService(IMapper mapper, IEmpresaRepository empresaRepository)
        {
            _mapper = mapper;
            _empresaRepository = empresaRepository;
        }
        
        
        public async Task<EmpresaDto> Adicionar(EmpresaDto dto)
        {
            var entity = _mapper.Map<Empresa>(dto);
            var retorno = await _empresaRepository.SalvarAsync(entity);

            return _mapper.Map<EmpresaDto>(retorno);
        }

        public async Task<EmpresaDto> Atualizar(EmpresaDto dto)
        {
            var entity = _mapper.Map<Empresa>(dto);
            var retorno = await _empresaRepository.AtualizarAsync(entity);

            return _mapper.Map<EmpresaDto>(retorno);
        }

        public async Task<ICollection<EmpresaDto>> BuscarListaAsync(Expression<Func<EmpresaDto, bool>> expression)
        {
            var expressionEntity = _mapper.Map<Expression<Func<Empresa, bool>>>(expression);

            var entities = await _empresaRepository.ListarQueryAsync(expressionEntity);

            List<EmpresaDto> dtos = entities.Select(x => _mapper.Map<EmpresaDto>(x)).ToList();

            return dtos;
        }

        public async Task<EmpresaDto> BuscarPorIdAsync(int id)
        {
            var entity = await _empresaRepository.BuscarPorIdAsync(id);

            return _mapper.Map<EmpresaDto>(entity);

        }

        public async Task Remover(int id)
        {
            _empresaRepository.Deletar(id);
        }
    }
}
