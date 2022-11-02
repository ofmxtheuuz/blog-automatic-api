using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Database;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Artigo> Artigos { get; set; }
}