namespace Backend.Models;

using System.Text.Json.Serialization;

//Sets the status of individual product items. 

public class Item : BaseModel
{
    public bool IsAvailable { get; set; } = true;

    [JsonIgnore]
    public int ProductId { get; set; }

    [JsonIgnore]
    public Product Product { get; set; } = null!;

    public string? Title { get => Product?.Title; }

    [JsonIgnore]
    public ICollection<Order> Orders { get; set; } = null!;
}