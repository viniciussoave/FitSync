using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Entities
{
    public class TreinoExercicio
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //Chave estrangeira Fisica
        public Guid TreinoId { get; set; }
        public Guid ExercicioId { get; set; }
        //Objeto de navegação
        public Treino Treino { get; set; } = null!;
        public Exercicio Exercicio { get; set; } = null!;

        //Exercicio
        public int Series { get; set; } = 0;
        public int Repeticoes { get; set; } = 0;
        public int TempoDescanso { get; set; } = 0;
        public int Ordem { get; set; } = 0;
    }
}
