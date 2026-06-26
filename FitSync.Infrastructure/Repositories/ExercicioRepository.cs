using FitSync.Domain.Entities;
using FitSync.Domain.Interfaces;
using FitSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitSync.Infrastructure.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly FitSyncDbContext _context;

        public ExercicioRepository(FitSyncDbContext context)
        {
            _context = context;
        }

        public async Task<Exercicio?> ObterPorIdAsync(Guid id)
        {
            return await _context.Exercicios
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Exercicio>> ObterTodosAsync()
        {
            return await _context.Exercicios
                .ToListAsync();
        }

        public async Task AdicionarAsync(Exercicio exercicio)
        {
            await _context.Exercicios.AddAsync(exercicio);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Exercicio exercicio)
        {
            _context.Exercicios.Update(exercicio);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio != null)
            {
                _context.Exercicios.Remove(exercicio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
