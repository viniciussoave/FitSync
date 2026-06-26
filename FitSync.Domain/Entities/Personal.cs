using System;
using System.Collections.Generic;
using System.Text;
using FitSync.Domain.Enum;

namespace FitSync.Domain.Entities
{
    public class Personal : Usuario
    {
        public string Cpf {  get; set; }

        public string Cref { get; set; }

        public Personal()
        {
            TipoUsuario = Enum.TipoUsuario.Personal;
        }
    }
}
