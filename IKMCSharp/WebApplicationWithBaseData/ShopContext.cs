
using Microsoft.EntityFrameworkCore;
using WebApplicationWithBaseData.Models;


public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}