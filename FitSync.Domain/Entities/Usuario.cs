using FitSync.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Entities
{
    public abstract class Usuario
    {
        public Guid Id { get;  set; } = Guid.NewGuid();
        public string Nome { get;  set; } = string.Empty;
        public string Email { get;  set; } = string.Empty;
        public string SenhaHash { get;  set; } = string.Empty;
        public TipoUsuario TipoUsuario { get;  set; }
        public DateTime DataCriacao { get;  set; } = DateTime.UtcNow;
        public bool Ativo { get;  set; } = true;

        public void AtualizarNome(string nome)
        {
            this.Nome = nome;
        }

        public void AlterarSenha(string senhaHash)
        {
            this.SenhaHash = senhaHash;
        }

        public void DesativarConta()
        {
            this.Ativo = false;
        }



    }
}
