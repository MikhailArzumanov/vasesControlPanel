using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using vaseApi.Models;

namespace vaseApi.Data {
    public class ApplicationContext : DbContext {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { 
            //Database.EnsureCreated();
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Genus> Genuses { get; set; }
        public DbSet<Vase>  Vases { get; set; }
    }
}
