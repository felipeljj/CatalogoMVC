using catalogoMVC.Models;
using Microsoft.EntityFrameworkCore;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; } //Tabela para os produtos
    public DbSet<User> Users { get; set; }   // Tabela para os usuários
}