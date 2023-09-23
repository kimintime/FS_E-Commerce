namespace Backend.Db;

using Microsoft.EntityFrameworkCore;
using Backend.Models;

public static class ProductConfigExtensions
{
    public static void ProductConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasIndex(product => product.Title)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .Navigation(product => product.Categories)
            .AutoInclude();

        modelBuilder.Entity<Product>()
            .Navigation(product => product.Items)
            .AutoInclude();
    }

    public static void CategoryConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
         .HasIndex(category => category.Name)
         .IsUnique();
    }

}