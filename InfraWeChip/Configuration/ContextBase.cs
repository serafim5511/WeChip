using EntitiesWeChip;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InfraWeChip.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=WeChip;Trusted_Connection=True;", 
                    options => options.EnableRetryOnFailure());
                base.OnConfiguring(optionsBuilder);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Nome)
                  .HasMaxLength(500);
                entity.Property(e => e.Cpf)
                  .HasMaxLength(500);
                entity.Property(e => e.Telefone)
                  .HasMaxLength(500);
                entity.Property(e => e.Credito)
                  .HasMaxLength(500);
                entity.Property(e => e.StatusAtual)
                  .HasMaxLength(500);
                entity.Property(e => e.Cep)
                  .HasMaxLength(500);
                entity.Property(e => e.Rua)
                  .HasMaxLength(500);
                entity.Property(e => e.Numero)
                  .HasMaxLength(500);
                entity.Property(e => e.Complemento)
                  .HasMaxLength(500);
                entity.Property(e => e.Bairro)
                  .HasMaxLength(500);
                entity.Property(e => e.Cidade)
                  .HasMaxLength(500);
                entity.Property(e => e.Estado)
                  .HasMaxLength(500);
            });
            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Descricao)
                  .HasMaxLength(500);
                entity.Property(e => e.CodigoProduto)
                  .HasMaxLength(500);
                entity.Property(e => e.Preco)
                  .HasMaxLength(500);
                entity.Property(e => e.Tipo)
                  .HasMaxLength(500);                
            });
        }
    }
}
