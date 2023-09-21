namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using System.IdentityModel.Tokens.Jwt;

//Defines the services for generating and reading JWT, using the IdentityModel JWT package

public interface IJWTokenService
{
    Task<LoginReponseDTO?> GenerateTokenAsync(User user);
    JwtSecurityToken ReadToken(string token);
}