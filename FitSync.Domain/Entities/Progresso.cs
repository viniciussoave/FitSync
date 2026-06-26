using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Entities
{
    public class Progresso
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //Chave estrangeira
        public Guid AlunoId { get; set; }
        public Guid ExercicioId { get; set; }
        //Objeto de Navegacao
        public Aluno Aluno { get; set; } = null!;
        public Exercicio Exercicio { get; set; } = null!;

        // Exercicio
        public float CargaUtilizada { get; set; } = 0;
        public int RepeticoesUtilizadas { get; set; } = 0;
        public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    }
}
