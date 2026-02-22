using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DatabaseContexts;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    public DbSet<TempFile> TempFiles { get; set; }
}
