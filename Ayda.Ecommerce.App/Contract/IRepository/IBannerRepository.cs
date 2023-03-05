using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Slider;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IBannerRepository
{
    Task<ResultDto> AddAsync(CreateBannerDto BannerDto);
    Task<ResultDto> UpdateAsync(UpdateBannerDto BannerDto);
    Task<ResultDto<IEnumerable<BannerDto>>> GetAllAsync();
    Task<ResultDto<BannerDto>> GetByIdAsync(int id);
    Task<ResultDto> RemoveAsync(int id);
    Task<ResultDto> ChangeIsShow(int id);
}