using Microsoft.EntityFrameworkCore;
using RecommendationAPI.Models;

namespace RecommendationAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Rating> Ratings { get; set; }
}