namespace Backend.DTOs;

using Backend.Models;

//Does not extend the Base class so I can get the exact response I want outside of those constraints

public class OrderResponseDTO
{
    public int Id { get; set; }
    public UserRegResponseDTO User { get; set; } = null!;
    public Item Item { get; set; } = null!;
    public DateTime DatePurchased { get; set; }

    public static OrderResponseDTO FromLoan(Order order)
    {
        return new OrderResponseDTO()
        {
            Id = order.Id,
            User = UserRegResponseDTO.FromUser(order.User),
            Item = order.Item,
            DatePurchased = order.DatePurchased,
        };
    }
}