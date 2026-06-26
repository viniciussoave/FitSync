using System;
using System.Collections.Generic;
using System.Text;
using FitSync.Domain.Enum;

namespace FitSync.Domain.Entities
{
    public class Administrador : Usuario
    {
        public Administrador()
        {
            TipoUsuario = Enum.TipoUsuario.Administrador;
        }
    }
}
