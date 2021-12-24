using Dyrt.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dyrt.Data.Context
{
    public class DyrtContext : DbContext
    {
        public DyrtContext(DbContextOptions<DyrtContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                
                property.SetColumnType("varchar(100)");
            

            modelBuilder.ApplyConfigurationsFromAssembly(typeof (DyrtContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}
