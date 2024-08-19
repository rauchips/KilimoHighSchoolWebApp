using KilimoWebApp.Modules.Streams.Model;
using KilimoWebApp.Modules.Students.Model;
using Microsoft.EntityFrameworkCore;

namespace KilimoWebApp.Common;

public class KilimoContext : DbContext
{
    public KilimoContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
    }

    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<StreamEntity> Streams { get; set; }
}