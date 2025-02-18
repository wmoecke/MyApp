using Microsoft.EntityFrameworkCore;
using MyApp.Domain;
namespace MyApp.Infrastructure 
{ 
    public class ApplicationDbContext : DbContext 
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 
        public DbSet<DataEntity> DataEntities { get; set; } 
    } 
}
