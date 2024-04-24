using Microsoft.EntityFrameworkCore;

namespace FuelManagerApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
    }
}