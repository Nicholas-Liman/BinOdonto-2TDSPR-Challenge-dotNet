using Microsoft.EntityFrameworkCore;
using BinOdonto.Domain.Entities;

namespace BinOdonto.Data.AppData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; } // Mantenha se necessário

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES");
                entity.Property(e => e.ClienteID).HasColumnName("CLIENTEID");
                entity.Property(e => e.Nome).HasColumnName("NOME");
                entity.Property(e => e.CPF).HasColumnName("CPF");
                entity.Property(e => e.DataNascimento).HasColumnName("DATANASCIMENTO");
                entity.Property(e => e.Email).HasColumnName("EMAIL");
                entity.Property(e => e.CEP).HasColumnName("CEP");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("FUNCIONARIOS");
                entity.Property(e => e.FuncionarioID).HasColumnName("FUNCIONARIOID");
                entity.Property(e => e.Nome).HasColumnName("NOME");
                entity.Property(e => e.CPF).HasColumnName("CPF");
                entity.Property(e => e.Cargo).HasColumnName("CARGO");
                entity.Property(e => e.Salario)
                    .HasColumnName("SALARIO")
                    .HasColumnType("decimal(18,2)");
                entity.Property(e => e.DataContratacao).HasColumnName("DATACONTRATACAO");
                entity.Property(e => e.CEP).HasColumnName("CEP");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
