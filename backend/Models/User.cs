namespace Backend.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

//Extends IdentityUser, so we just need the first and last name, and image address here
//Along with each user's order history

public class User : IdentityUser<int>
{
    [MinLength(1)]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [MinLength(1)]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Order> Orders { get; set; } = null!;

}