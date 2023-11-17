using API.Core.Application.Dto;
using API.Core.Application.Interfaces;
using API.Core.Domain;
using API.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Category> GetCategoryWithProductsAsync(int id)
        {
            var categoryWitProducts=await _appDbContext.Categories.Where(x=>x.Id == id).Include(x=>x.Products).SingleOrDefaultAsync();
            return categoryWitProducts;
        }
    }
}
