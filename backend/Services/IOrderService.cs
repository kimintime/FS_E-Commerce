namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;

//Defines the order services, getting orders by user)

public interface ILoanService : ICrudService<Order, OrderDTO>
{
    public Task<ICollection<Order>> GetOrdersByUserAsync(int userId);

}