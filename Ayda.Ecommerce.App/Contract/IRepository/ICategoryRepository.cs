using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface ICategoryRepository
{
    Task<ResultDto> AddAsync(CreateCategoryDto categoryDto);
    Task<ResultDto> RemoveAsync(int id);
    Task<ResultDto> UpdateAsync(UpdateCategoryDto categoryDto);
    Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync(int? id);
    Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync();
    Task<ResultDto<CategoryDto>> GetByIdAsync(int id);
    Task<ResultDto> AddAtributeAsync(CreateCategoryAttributeDto attr);
    Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAllCategoryAttributeAsync(int childCategoryId);
    Task<ResultDto> UpdateAttributeAsync(UpdateCategoryAttributeDto attr);
    Task<ResultDto> RemoveCategoryAttrbuteAsync(int id);
    Task<ResultDto<IEnumerable<CategoryDto>>> GetForCategory();
}