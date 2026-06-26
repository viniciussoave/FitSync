using FitSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitSync.Infrastructure.Data
{
    public class FitSyncDbContext : DbContext
    {
        public FitSyncDbContext(DbContextOptions<FitSyncDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Personal> Personais { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<TreinoExercicio> TreinoExercicios { get; set; }
        public DbSet<Progresso> Progressos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().UseTphMappingStrategy();

            modelBuilder.Entity<TreinoExercicio>()
                .HasOne(te => te.Treino)
                .WithMany(t => t.Exercicios)
                .HasForeignKey(te => te.TreinoId);

            modelBuilder.Entity<TreinoExercicio>()
                .HasOne(te => te.Exercicio)
                .WithMany(e => e.Treinos)
                .HasForeignKey(te => te.ExercicioId);

            var adminMasterId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = adminMasterId,
                    Nome = "Admin Master FitSync",
                    Email = "admin@fitsync.com",
                    SenhaHash = "123",
                    DataCriacao = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    Ativo = true,
                    TipoUsuario = Domain.Enum.TipoUsuario.Administrador
                }
            );
        }
    }
}