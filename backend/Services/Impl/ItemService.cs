namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;

public class CopyService : CrudService<Item, ItemDTO>
{
    public CopyService(AppDbContext dbContext) : base(dbContext)
    {
    }
}