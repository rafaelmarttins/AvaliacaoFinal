using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Domain.EF
{
    public partial class AvaliarContext : DbContext
    {
        public DbSet<Rebanho> Rebanhos { get; set; } = null!;

        public DbSet<TipoRebanho> TipoRebanhos { get; set; } = null!;

        public AvaliarContext() : base()
        { }

        public AvaliarContext(DbContextOptions<AvaliarContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Aqui ficava a Connection StrinSg.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Rebanho>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TipoRebanho>(entity =>
            {
                entity.Property(e => e.Situacao).HasDefaultValueSql("((1))");

                entity.Property(e => e.DataDeInsercao).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
