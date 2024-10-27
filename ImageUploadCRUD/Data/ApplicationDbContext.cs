using ImageUploadCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageUploadCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        { 
        }
        public DbSet<ProductsList> ProductsImg { get; set; }
    }
}
