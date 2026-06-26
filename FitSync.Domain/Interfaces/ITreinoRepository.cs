using FitSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Interfaces
{
    public interface ITreinoRepository
    {
        Task<Treino?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Treino>> ObterTodosAsync();
        Task AdicionarAsync(Treino treino);
        Task AtualizarAsync(Treino treino);
        Task RemoverAsync(Guid id);
    }
}
