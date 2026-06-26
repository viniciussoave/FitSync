using FitSync.Domain.Entities;
using FitSync.Domain.Interfaces;
using FitSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Infrastructure.Repositories
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly FitSyncDbContext _context;

        public TreinoRepository(FitSyncDbContext context)
        {
            _context = context;
        }

        public async Task<Treino?> ObterPorIdAsync(Guid id)
        {
            return await _context.Treinos
                .Include(t => t.Exercicios)
                    .ThenInclude(te => te.Exercicio)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Treino>> ObterTodosAsync()
        {
            return await _context.Treinos.ToListAsync();
        }

        public async Task AdicionarAsync(Treino treino)
        {
            await _context.Treinos.AddAsync(treino);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Treino treino)
        {
            _context.Treinos.Update(treino);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var treino = await _context.Treinos.FindAsync(id);
            if (treino != null)
            {
                _context.Treinos.Remove(treino);
                await _context.SaveChangesAsync();
            }
        }
    }
}
