namespace Backend.Models;

using System.ComponentModel.DataAnnotations;

//Here we have product description and name, with its category and amount in inventory

public class Product : BaseModel
{
    [MinLength(1)]
    [MaxLength(250)]
    public string Title { get; set; } = null!;

    [MaxLength(500)]
    public string? Description { get; set; }

    public ICollection<Category> Categories { get; set; } = null!;

    public ICollection<Item> Items { get; set; } = null!;

    
    public int ItemsAvailable 
    { 
        get => Items == null ? 0 : Items.Where(c => c.IsAvailable).Count();
    }

}