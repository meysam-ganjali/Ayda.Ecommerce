using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;
using Microsoft.AspNetCore.Http;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IUserRepository
{
    ResultDto<GetForAdmin<ApplicationUserDto>> GetUserForAdmin(string? filterUser, string? search = null, int pageSize = 100, int pageNumber = 1);
    Task<ResultDto> LockOnLockAsync(long id);
    Task<ResultDto> ActiveDeActiveAsync(long id);
    Task<ResultDto> ChangeRoleAsync(long UserId, int RoleId);
    Task<ResultDto<ApplicationUserDto>> GetUserByIdAsync(long id);
    Task<ResultDto> AddOrChangeAvatar(long UserId, IFormFile avatar);
}