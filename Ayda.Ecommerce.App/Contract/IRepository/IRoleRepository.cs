using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Role;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IRoleRepository
{
    Task<ResultDto> AddAsync(CreateRoleDto role);
    Task<ResultDto> RemoveAsync(int id);
    Task<ResultDto<RoleDto>> GetByAsync(string name);
    Task<ResultDto<RoleDto>> GetByAsync(int id);
    Task<ResultDto<IEnumerable<RoleDto>>> GetAllAsync();
}