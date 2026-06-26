using FitSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Domain.Interfaces
{
    public interface IProgressoRepository
    {
        Task<Progresso?> ObterPorIdAsync(Guid id);
        Task<IEnumerable<Progresso>> ObterTodosAsync();
        Task AdicionarAsync(Progresso progresso);
        Task AtualizarAsync(Progresso progresso);
        Task RemoverAsync(Guid id);
    }
}
