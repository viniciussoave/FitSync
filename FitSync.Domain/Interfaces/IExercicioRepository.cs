using FitSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Interfaces
{
    public interface IExercicioRepository
    {
        Task<Exercicio?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Exercicio>> ObterTodosAsync();
        Task AdicionarAsync(Exercicio exercicio);
        Task AtualizarAsync(Exercicio exercicio);
        Task RemoverAsync(Guid id);
    }
}
