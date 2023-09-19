namespace Backend.DTOs;

using Backend.Models;

public class OrderDTO : BaseDTO<Order>
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public DateTime DatePurchased { get; set;}

    public override void UpdateModel(Order model)
    {
        model.DatePurchased = DatePurchased;
    }
}