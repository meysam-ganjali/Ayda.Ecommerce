using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IUserRepository
{
    ResultDto<UserForAdmin> GetUserForAdmin(string? filterUser, string? filter = null, int pageSize = 100, int pageNumber = 1);
    Task<ResultDto> LockOnLockAsync(long id);
    Task<ResultDto> ActiveDeActiveAsync(long id);
    Task<ResultDto> ChangeRoleAsync(long UserId, int RoleId);
}