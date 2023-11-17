using API.Core.Application.Dto;
using API.Core.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace API.Core.Application.Features.CQRS.Queries.CategoryWithProducts
{
    public class CategoryWithProductsQueryHandler : IRequestHandler<CategoryWithProductsQuery, CategoryWithProductsDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryWithProductsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryWithProductsDto> Handle(CategoryWithProductsQuery request, CancellationToken cancellationToken)
        {
            var categoryWithProducts= await _categoryRepository.GetCategoryWithProductsAsync(request.Id);
            if (categoryWithProducts == null) { }
            var categoryWithProductsDto= _mapper.Map<CategoryWithProductsDto>(categoryWithProducts);
            return categoryWithProductsDto;
        }
    }
}
