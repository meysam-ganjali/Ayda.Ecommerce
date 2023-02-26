using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IAuthenticationRepository
{
    Task<ResultDto<AuthResultDto>> LoginAsync(LoginDto loginDto);
    Task<ResultDto> RegisterForAdminAsync(CreateApplicationUserDto userDto);
    Task<ResultDto<AuthResultDto>> RegisterAsync(RegisterApplicationUserDto userDto);
}