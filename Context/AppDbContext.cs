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
        public required DbSet<User> Users { get; set; } 
        public required DbSet<Category> Categories { get; set; } 
        public required DbSet<Product> Products { get; set; } 
        public required DbSet<Status> Status { get; set; } 
        public required DbSet<Order> Orders { get; set; } 
        public required DbSet<ProductOrder> ProductOrders { get; set; } 
        public required DbSet<UserOrder> UserOrders { get; set; } 
    }
}