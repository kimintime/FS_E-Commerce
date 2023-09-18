namespace Backend.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//Sets up the catagories image, name, desc, and their products

public class Category : BaseModel
{
    [MinLength(3)]
    [MaxLength(10)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Image { get; set; } = null!;


    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = null!;
}