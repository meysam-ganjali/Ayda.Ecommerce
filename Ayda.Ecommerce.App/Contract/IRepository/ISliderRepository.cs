using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Slider;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface ISliderRepository {
    Task<ResultDto> AddAsync(CreateSliderDto sliderDto);
    Task<ResultDto> UpdateAsync(UpdateSliderDto sliderDto);
    Task<ResultDto<IEnumerable<SliderDto>>> GetAllAsync();
    Task<ResultDto<SliderDto>> GetByIdAsync(int id);
    Task<ResultDto> RemoveAsync(int id);
    Task<ResultDto> ChangeIsShow(int id);
}