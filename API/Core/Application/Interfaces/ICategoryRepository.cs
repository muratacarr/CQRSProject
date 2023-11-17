using API.Core.Application.Dto;
using API.Core.Domain;

namespace API.Core.Application.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(int id);
    }
}
