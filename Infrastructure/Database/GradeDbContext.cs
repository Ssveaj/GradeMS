

using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class GradeDbContext : DbContext
    {
        public GradeDbContext(DbContextOptions<GradeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public DbSet<Grade> Grades { get; set; } = default!;
    }
}
