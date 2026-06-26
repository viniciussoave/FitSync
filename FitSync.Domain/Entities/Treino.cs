using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Entities
{
    public class Treino
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //Chave estrangeira
        public Guid PersonalId { get; set; }
        public Guid AlunoId { get; set; }
        //Objeto de navegacao
        public Personal Personal { get; set; } = null!;
        public Aluno Aluno { get; set; } = null!;

        // Treino
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public ICollection<TreinoExercicio> Exercicios { get; set; } = new List<TreinoExercicio>();

        
    }
}
