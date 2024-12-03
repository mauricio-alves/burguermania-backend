using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

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

        // Popula as tabelas de categorias, produtos, status e usuários com dados iniciais no banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data de Categorias
            foreach (var category in SeedData.Categories)
            {
                modelBuilder.Entity<Category>().HasData(category);
            }

            // Seed Data de Produtos
            foreach (var product in SeedData.Products)
            {
                modelBuilder.Entity<Product>().HasData(product);
            }

            // Seed Data de Status
            foreach (var status in SeedData.Status)
            {
                modelBuilder.Entity<Status>().HasData(status);
            }

            // Seed Data de Usuários
            foreach (var user in SeedData.Users)
            {
                modelBuilder.Entity<User>().HasData(user);
            }
        }
    }
}