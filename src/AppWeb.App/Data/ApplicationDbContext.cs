using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Dyrt.App.ViewModels;

namespace AppWeb.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Dyrt.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
    }
}
