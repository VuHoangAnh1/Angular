using LearnAngular.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAngular.API.Data
{
    public class HotelsDbContext : DbContext
    {
        public HotelsDbContext(DbContextOptions options) : base(options)
        {
             
        }

        //Dbset
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
