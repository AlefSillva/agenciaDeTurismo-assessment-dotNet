using Microsoft.EntityFrameworkCore;
using TurismoApp.Models;

namespace TurismoApp.Data
{
    public class AgenciaTurismoContext : DbContext
    {
        public AgenciaTurismoContext(DbContextOptions<AgenciaTurismoContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<PaisDestino> PaisDestino { get; set; } = null!;
        public DbSet<CidadeDestino> CidadesDestino { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.PacoteTuristico)
                .WithMany(p => p.Reservas)
                .HasForeignKey(r => r.PacoteTuristicoId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<CidadeDestino>()
                .HasOne(cd => cd.PaisDestino)
                .WithMany(pd => pd.CidadesDestino)
                .HasForeignKey(cd => cd.PaisDestinoId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(p => p.CidadesDestino)
                .WithMany(c => c.PacotesTuristicos)
                .UsingEntity(j => j.ToTable("PacoteCidadeDestino"));

            
            modelBuilder.Entity<Cliente>().HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
