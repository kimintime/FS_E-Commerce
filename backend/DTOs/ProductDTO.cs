namespace Backend.DTOs;

using Backend.Models;


public class ProductDTO : BaseDTO<Product>
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public override void UpdateModel(Product model)
    {
        model.Title = Title;
        model.Description = Description;
        model.Image = Image;
    }
}