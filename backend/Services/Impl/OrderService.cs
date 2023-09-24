namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class OrderService : IOrderService
{
    private readonly AppDbContext _dbContext;
    
    public OrderService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<Order>> GetAllAsyncPagination(int page = 1, int pageSize = 25)
    {
        return await _dbContext.Orders
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<ICollection<Order>> GetAllAsync()
    {
        return await _dbContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetAsync(int id)
    {
        return await _dbContext.FindAsync<Order>(id);
    }

    public async Task<ICollection<Order>> GetOrdersByUserAsync(int userId)
    {
        return await _dbContext.Orders
            .Where(order => order.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Order?> CreateAsync(OrderDTO request)
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

    public async Task<Order?> UpdateAsync(int id, OrderDTO request)
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

    public async Task<bool> DeleteAsync(int id)
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
