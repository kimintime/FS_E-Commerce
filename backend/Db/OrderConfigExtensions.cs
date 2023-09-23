namespace Backend.Db;

using Microsoft.EntityFrameworkCore;
using Backend.Models;

public static class OrderConfigExentions {

    public static void ItemConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .Navigation(item => item.Product)
            .AutoInclude();
    }
    
    public static void OrderConfig(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasOne(order => order.User)
            .WithMany(user => user.Orders)
            .OnDelete(DeleteBehavior.SetNull)
            .HasForeignKey(order => order.UserId);

        modelBuilder.Entity<Order>()
            .Navigation(order => order.User)
            .AutoInclude();

        modelBuilder.Entity<Order>()
            .HasOne(order => order.Item)
            .WithMany(item => item.Orders)
            .OnDelete(DeleteBehavior.SetNull)
            .HasForeignKey(order => order.ItemId);

        modelBuilder.Entity<Order>()
            .Navigation(order => order.Item)
            .AutoInclude();
    }
}