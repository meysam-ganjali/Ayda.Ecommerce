using Ayda.Ecommerce.ShareModels.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayda.Ecommerce.ShareModels.Menu;

public class MenuItemDto : BaseDto<int> {
    public string Name { get; set; }
    public List<SubMenuDto> SubMenus { get; set; }
}
public class CreateMenuItemDto {
    public string Name { get; set; }

}
public class UpdateMenuItemDto : BaseDto<int> {
    public string Name { get; set; }

}