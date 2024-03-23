using AutoMapper;
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
    public class ServiceBase<T, D> : IServiceBase<T> where T : class where D : EntityBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<D> _repositoryBase;

        public ServiceBase(IMapper mapper, IRepositoryBase<D> repositoryBase)
        {
            _mapper = mapper;
            _repositoryBase = repositoryBase;
        }
        public async Task<T> Adicionar(T dto)
        {
            var entity = _mapper.Map<D>(dto);
            var retorno = await _repositoryBase.SalvarAsync(entity);

            return _mapper.Map<T>(retorno);
        }

        public async Task<T> Atualizar(T dto)
        {
            var entity = _mapper.Map<D>(dto);
            var retorno = await _repositoryBase.AtualizarAsync(entity);

            return _mapper.Map<T>(retorno);
        }

        public async Task<ICollection<T>> BuscarListaAsync()
        {
            var entities = await _repositoryBase.ListarQueryAsync(x => true);

            List<T> dtos = entities.Select(x => _mapper.Map<T>(x)).ToList();
            return dtos;
        }

        public async Task<ICollection<T>> BuscarListaComQueryAsync(Expression<Func<T, bool>> expression)
        {
            var expressionEntity = _mapper.Map<Expression<Func<D, bool>>>(expression);

            var entities = await _repositoryBase.ListarQueryAsync(expressionEntity);

            List<T> dtos = entities.Select(x => _mapper.Map<T>(x)).ToList();

            return dtos;
        }

        public async Task<T> BuscarPorIdAsync(int id)
        {
            var entity = await _repositoryBase.BuscarPorIdAsync(id);

            return _mapper.Map<T>(entity);

        }

        public async Task Remover(int id)
        {
            _repositoryBase.Deletar(id);           
        }
    }
}
