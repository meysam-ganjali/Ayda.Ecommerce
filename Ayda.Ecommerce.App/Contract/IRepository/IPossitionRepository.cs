using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Slider;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IPossitionRepository
{
    Task<ResultDto<IEnumerable<PossitionDto>>> GetPossitionAsync();
}