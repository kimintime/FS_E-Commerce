namespace Backend.DTOs;

using Backend.Models;
using System.ComponentModel.DataAnnotations;

public class ItemDTO : BaseDTO<Item>
{
    [Required]
    public int ProductId { get; set; }

    public override void UpdateModel(Item model)
    {
        model.ProductId = ProductId;
    }
}