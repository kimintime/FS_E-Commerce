namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;

//Defines all of the user services: Register, login, get, getAll w/ and w/o
//pagination, update, update password, and delete. 

public interface IUserService
{
    Task<User?> RegisterAsync(UserRegistrationDTO request);
    Task<LoginReponseDTO?> LoginAsync(CredentialsDTO request);
    
    Task<User?> GetAsync(string id);

    Task<IEnumerable<UserDTO>> GetAllAsyncPagination(int page = 1, int pageSize = 25);
    Task<IEnumerable<UserDTO>> GetAllAsync();

    Task<User?> UpdateUserAsync(UpdateUserDTO request, string id);
    Task<bool> UpdatePasswordAsync(UpdatePasswordDTO request, string id);

    Task<bool> DeleteUserAsync(string id);
}