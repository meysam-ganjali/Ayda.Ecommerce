using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface ICategoryRepository
{
    Task<ResultDto> AddAsync(CreateCategoryDto categoryDto);
    Task<ResultDto> RemoveAsync(int id);
    Task<ResultDto> UpdateAsync(UpdateCategoryDto categoryDto);
    Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync(int? id);
    Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync();
    Task<ResultDto<CategoryDto>> GetByIdAsync(int id);
}