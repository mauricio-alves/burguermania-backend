using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Context
{
    // Define o contexto do banco de dados
    public class AppDbContext : DbContext 
    {
        // Define o construtor do contexto
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define as tabelas do banco de dados
        public DbSet<User> Users { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<Status> Status { get; set; } 
        public DbSet<Order> Orders { get; set; } 
        public DbSet<ProductOrder> ProductOrders { get; set; } 
        public DbSet<UserOrder> UserOrders { get; set; } 
    }
}