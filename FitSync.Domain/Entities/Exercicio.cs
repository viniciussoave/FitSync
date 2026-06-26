using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Entities
{
    public class Exercicio
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Exercicio
        public string Nome { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;

        public ICollection<TreinoExercicio> Treinos { get; set; } = new List<TreinoExercicio>();

        
    }
}
