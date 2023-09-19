namespace Backend.DTOs;

using Backend.Models;

//The response DTO after user registration

public class UserRegResponseDTO
{
    public int Id { get; init; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Username { get; set; }
    public string Email { get; set; } = null!;
    public string Avatar { get; set; } = null!;

    public static UserRegResponseDTO FromUser(User user)
    {
        return new UserRegResponseDTO
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.UserName,
            Email = user.Email!,
            Avatar = user.Avatar
        };
    }

}