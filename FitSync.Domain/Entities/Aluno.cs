using System;
using System.Collections.Generic;
using System.Text;
using FitSync.Domain.Enum;

namespace FitSync.Domain.Entities
{
    public class Aluno : Usuario
    {
        public DateTime DataNascimento {  get; set; }

        public float Peso { get; set; }

        public Aluno()
        {
            TipoUsuario = Enum.TipoUsuario.Aluno;
        }
    }
}
