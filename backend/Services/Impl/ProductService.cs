namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;
using Backend.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;


public class ProductService : CrudService<Product, ProductDTO>, IProductService
{
    public ProductService(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<Product>?> GetProductsByTitlePagination(string searchTitle, int page = 1, int pageSize = 25)
    {
        if (searchTitle is null)
            return null;
        

        return await _dbContext.Products
            .Where(product => product.Title.ToLower().Contains(searchTitle.ToLower()))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<ICollection<Product>?> GetProductsByTitle(string searchTitle)
    {
        if (searchTitle is null)
            return null;
        

        return await _dbContext.Products
            .Where(product => product.Title.ToLower().Contains(searchTitle.ToLower()))
            .ToListAsync();
    }

    public async Task<ICollection<Product>?> GetProductsByCategoryPagination(int categoryId, int page = 1, int pageSize = 25)
    {
        return await _dbContext.Products
            .Where(product => product.Categories.Select(category => category.Id).Contains(categoryId))
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<ICollection<Product>?> GetProductsByCategory(int categoryId)
    {
        return await _dbContext.Products
            .Where(product => product.Categories.Select(category => category.Id).Contains(categoryId))
            .ToListAsync();
    }

    public async Task<bool> AddCategoryToProduct(int id, AddDTO request)
    {
        var product = await _dbContext.Products.SingleOrDefaultAsync(product => product.Id == id);
        var category = await _dbContext.Categories.SingleOrDefaultAsync(category => category.Id == request.AddId);

        if (product is null || category is null)
            return false;

        product.Categories.Add(category);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveCategoryFromProduct(int id, int categoryId)
    {
        var product = await _dbContext.Products.FindAsync(id);
        var category = await _dbContext.Categories.FindAsync(categoryId);

        if (product is null || category is null)
            return false;

        product.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}