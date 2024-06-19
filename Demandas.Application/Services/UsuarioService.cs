using AutoMapper;
using Demandas.Application.DTOs;
using Demandas.Application.Interfaces;
using Demandas.Domain.Entities;
using Demandas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demandas.Application.Services
{
    public class UsuarioService : ServiceBase<UsuarioDto, Usuario>, IUsuarioService
    {
        private readonly IMapper mapper;
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository) : base(mapper, usuarioRepository)
        {
            this.mapper = mapper;
            this.usuarioRepository = usuarioRepository;
        }


        public async Task<UsuarioDto> BuscaPorLogin(string login) { 
            return this.mapper.Map<UsuarioDto>(await usuarioRepository.BuscarPorLogin(login));
        }

        public async Task<UsuarioDto> Adicionar(UsuarioDto dto)
        {
            dto.Senha = HashPassword(dto.Senha);
            return await base.Adicionar(dto);
        }

        public async Task<UsuarioDto> Atualizar(UsuarioDto dto)
        {
            var usuarioExistente = await usuarioRepository.BuscarPorIdAsync(dto.Id);
            if (usuarioExistente == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            // Salva a senha atual
            var senhaAtual = usuarioExistente.Senha;

            // Atualiza o usuário com os novos dados, exceto a senha
            var usuarioAtualizado = mapper.Map(dto, usuarioExistente);

            // Restaura a senha original
            usuarioAtualizado.AtualizarSenha(senhaAtual);

            // Salva as alterações no banco de dados
            await usuarioRepository.AtualizarAsync(usuarioAtualizado);

            return mapper.Map<UsuarioDto>(usuarioAtualizado);
        }


        public async Task<bool> AtualizarSenha(int usuarioId, string novaSenha)
        {
            var usuario = await usuarioRepository.BuscarPorIdAsync(usuarioId);
            if (usuario == null)
            {
                return false; // Usuário não encontrado
            }

            usuario.AtualizarSenha(HashPassword(novaSenha));
            await usuarioRepository.AtualizarAsync(usuario);
            return true;
        }

        private static string HashPassword(string password)
        {
            // Gerar um salt aleatório
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Criar o hash da senha com um algoritmo de hash seguro e número de iterações explícito
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combinar o salt e o hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Converter para base64
            string passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        public async Task<bool> ValidarSenha(string login, string senhaFornecida)
        {
            // Buscar o usuário pelo login
            var usuario = await usuarioRepository.BuscarPorLogin(login);

            if (usuario == null)
            {
                // Usuário não encontrado
                return false;
            }

            // Extrair o salt e o hash da senha armazenada
            byte[] hashBytes = Convert.FromBase64String(usuario.Senha);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Gerar o hash da senha fornecida usando o mesmo salt
            var pbkdf2 = new Rfc2898DeriveBytes(senhaFornecida, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            // Comparar o hash gerado com o hash armazenado
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false; // Senha incorreta
                }
            }

            return true; // Senha correta
        }
    }
}
