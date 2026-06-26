using FitSync.Domain.Entities;
using FitSync.Domain.Interfaces;
using FitSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Infrastructure.Repositories
{
    public class ProgressoRepository : IProgressoRepository
    {
        private readonly FitSyncDbContext _context;

        public ProgressoRepository(FitSyncDbContext context)
        {
            _context = context;
        }

        public async Task<Progresso?> ObterPorIdAsync(Guid id)
        {
            return await _context.Progressos
                .Include(p => p.Aluno)
                .Include(p => p.Exercicio)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Progresso>> ObterTodosAsync()
        {
            return await _context.Progressos
                .Include(p => p.Aluno)
                .Include(p => p.Exercicio)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Progresso progresso)
        {
            await _context.Progressos.AddAsync(progresso);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Progresso progresso)
        {
            _context.Progressos.Update(progresso);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var progresso = await _context.Progressos.FindAsync(id);
            if (progresso != null)
            {
                _context.Progressos.Remove(progresso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
