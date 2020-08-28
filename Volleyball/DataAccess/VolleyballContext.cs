using Microsoft.EntityFrameworkCore;
using Volleyball.DataAccess.Models;

namespace Volleyball.DataAccess
{
    public class VolleyballContext : DbContext
    {
        public VolleyballContext(DbContextOptions<VolleyballContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}