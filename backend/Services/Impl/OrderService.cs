namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

//Overrides of Create, Update, and Delete methods in order to set item availability and purchase date

public class OrderService : CrudService<Order, OrderDTO>, IOrderService
{
    public OrderService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<Order>> GetOrdersByUserAsync(int userId)
    {
        return await _dbContext.Orders
            .Where(order => order.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<Order?> CreateAsync(OrderDTO request)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == request.UserId);

        if (user is null)
            return null;

        var item = await _dbContext.Item.SingleOrDefaultAsync(item => item.Id == request.ItemId);

        if (item is null)
            return null;

        item.IsAvailable = false;

        var order = new Order()
        {
            ItemId = item.Id,
            UserId = user.Id,
            DatePurchased = DateTime.Now,
        };

        _dbContext.Orders.Add(order);

        await _dbContext.SaveChangesAsync();

        return order;
    }

    public override async Task<Order?> UpdateAsync(int id, OrderDTO request)
    {
        var order = await _dbContext.Orders.SingleOrDefaultAsync(loan => loan.Id == id);

        if (order is null)
            return null;

        if (order.UserId != request.UserId)
            return null;

        request.UpdateModel(order);
        await _dbContext.SaveChangesAsync();
        return order;
    }

    public override async Task<bool> DeleteAsync(int id)
    {
        var order = await _dbContext.Orders.FindAsync(id);

        if (order is null)
            return false;

        order.Item.IsAvailable = true;
        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
