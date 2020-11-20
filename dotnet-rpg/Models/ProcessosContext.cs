using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace dotnet_rpg.Models
{
  public class ProcessoContext: DbContext
  {
    public DbSet<Processo> Processos { get; set; }

    public DbSet<Movimentacoes> Movimentacoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // Senha deve ser inserida
      optionsBuilder.UseMySQL("server=localhost;database=processos;user=root;password=********");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Processo>(entity =>
      {
        entity.HasKey(e => e.numeroProcesso);
        entity.Property(e => e.classe);
        entity.Property(e => e.area);
        entity.Property(e => e.assunto);
        entity.Property(e => e.origem);
        entity.Property(e => e.distribuicao);
        entity.Property(e => e.relator);
      });

      modelBuilder.Entity<Movimentacoes>(entity =>
      {
        entity.HasKey(e => e.numeroProcesso);
        entity.Property(e => e.movimentacao).IsRequired();
      });
    }
  }
}