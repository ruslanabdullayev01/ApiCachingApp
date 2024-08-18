using ApiCachingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCachingApp.Data
{
    public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
    {
        public DbSet<Driver> Drivers { get; set; }
    }
}
