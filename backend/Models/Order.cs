namespace Backend.Models;
using Backend.DTOs;
using System.Text.Json.Serialization;

//Tracks the order history of each user

public class Order : BaseModel
{
    public bool Returned { get; set; } = false;
    
    [JsonIgnore]
    public int UserId { get; set; }

    [JsonIgnore]
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;

    //[JsonIgnore]
    public User User { get; set; } = null!;
    public DateTime DatePurchased { get; set; }

    public UserRegResponseDTO? UserInfo => User != null ? UserRegResponseDTO.FromUser(User) : null;
}