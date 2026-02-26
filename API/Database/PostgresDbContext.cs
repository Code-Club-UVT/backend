using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Database;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public DbSet<TempFile> TempFiles { get; set; }
    public DbSet<TempHomework> TempHomeworks { get; set; }
    public DbSet<TempPassword> TempPasswords { get; set; }
}
