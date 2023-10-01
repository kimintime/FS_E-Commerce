namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

//GetAsync overrides the generic method so as to get the products associated with a given categoryId.

public class CategoryService : CrudService<Category, CategoryDTO>
{
    public CategoryService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<Category?> GetAsync(int id)
    {
        return await _dbContext.Categories
            .Include(category => category.Products)
            .FirstAsync(category => category.Id == id);
    }
}