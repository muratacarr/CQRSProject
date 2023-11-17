using API.Core.Domain;

namespace API.Core.Application.Dto
{
    public class CategoryWithProductsDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public ICollection<ProductsToBeDisplayedinCategoryDto> Products { get; set; }
    }
}
