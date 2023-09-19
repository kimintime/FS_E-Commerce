namespace Backend.DTOs;

using Backend.Models;
using System.ComponentModel.DataAnnotations;

public class CategoryDTO : BaseDTO<Category>
{
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public override void UpdateModel(Category model)
    {
        model.Name = Name;
        model.Description = Description;
        model.Image = Image;
    }
}