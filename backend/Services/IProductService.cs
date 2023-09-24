namespace Backend.Services;

using Backend.Models;
using Backend.DTOs;

//

public interface IProductService : ICrudService<Product, ProductDTO>
{
    public Task<bool> AddCategoryToProduct(int id, AddDTO request);
    public Task<bool> RemoveCategoryFromProduct(int id, int categoryId);
    
    public Task<ICollection<Product>?> GetProductsByCategoryPagination(int categoryId, int page = 1, int pageSize = 25);
    public Task<ICollection<Product>?> GetProductsByCategory(int categoryId);
    
    public Task<ICollection<Product>?> GetProductsByTitlePagination(string searchTitle, int page = 1, int pageSize = 25);
    public Task<ICollection<Product>?> GetProductsByTitle(string searchTitle);
}