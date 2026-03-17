using Microsoft.EntityFrameworkCore;
using AIAnomaly.Domain.Models;

namespace AIAnomaly.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Log> Logs { get; set; }

    public DbSet<Server> Servers { get; set; }

    public DbSet<Anomaly> Anomalies { get; set; }
}