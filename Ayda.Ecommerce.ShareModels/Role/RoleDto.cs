using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.Role;

public class RoleDto:BaseDto<int>
{
    public string Name { get; set; }
    public  List<ApplicationUserDto> ApplicationUsers { get; set; }
}