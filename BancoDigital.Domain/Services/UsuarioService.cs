using BancoDigital.Domain.Models;
using BancoDigital.Domain.Repository;
using BancoDigital.Domain.Repository.Interfaces;
using CPFCNPJ;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BancoDigital.Domain.Services
{
    public class UsuarioService : IUsuarioPFInterface
    {
        private readonly BancoDigitalDBContext _bancoDigitalDBContext;

        public UsuarioService(BancoDigitalDBContext bancoDigitalDBContext)
        {
           _bancoDigitalDBContext = bancoDigitalDBContext;
        }

        public async Task<UsuarioPF> AddUsuario(UsuarioPF usuario)
        {
            _bancoDigitalDBContext.UsuarioPFS.Add(usuario);
            _bancoDigitalDBContext.SaveChanges();

            return usuario;
        }

        public async Task<UsuarioPF> AtualizarUsuario(UsuarioPF usuario,string cpf)
        {
            UsuarioPF usuarioPorCPF = await BuscarUsuario(cpf);
            if(usuarioPorCPF == null)
            {
                throw new Exception($"CPF:{cpf} Não encontrado no Banco de Dados");
            }
            usuarioPorCPF.Nome= cpf;
            usuarioPorCPF.CEP = cpf;
            
            _bancoDigitalDBContext.UsuarioPFS.Update(usuarioPorCPF);
            _bancoDigitalDBContext.SaveChanges();
            
            return usuarioPorCPF;
        }

        public async Task<List<UsuarioPF>> BuscarTodosUsuarios()
        {
            return await _bancoDigitalDBContext.UsuarioPFS.ToListAsync();
        }

        public async Task<UsuarioPF> BuscarUsuario(string cpf)
        {
            return await _bancoDigitalDBContext.UsuarioPFS.FirstOrDefaultAsync(x => x.CPF == cpf);
        }

        public async Task <bool> RemoverPessoaFisica(string cpf)
        {
            UsuarioPF buscarCpf = await BuscarUsuario(cpf);
            
            if(buscarCpf == null)
            {
                throw new Exception($"Usuario Não encontrado Pelo: {cpf} ");
            }

            _bancoDigitalDBContext.UsuarioPFS.Remove(buscarCpf);
            _bancoDigitalDBContext.SaveChanges();

            return true;

        }

        public bool ValidarCpf(string cpf)
        {
           CPFCNPJ.Main validarCPF = new CPFCNPJ.Main();
           var resultado = validarCPF.IsValidCPFCNPJ(cpf);
         
            return resultado;
        }

        public bool VerificarCadastroPF(string cpf)
        {
            if(_bancoDigitalDBContext.UsuarioPFS.Any(x =>x.CPF == cpf))
            {
                UsuarioPF usuarioASerEncontrado = _bancoDigitalDBContext.UsuarioPFS.Where(item => item.CPF == cpf).First();
                return _bancoDigitalDBContext.UsuarioPFS.Contains(usuarioASerEncontrado);
            }
            return false;
        }

        public bool VerificarMaiorIdade(UsuarioPF usuarioPF)
        {
           if(usuarioPF.Idade >=18) 
            {
                return true;
            }
           else
            {
                return false;
            }

        }
    }
}
