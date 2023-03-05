using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;

namespace Ayda.Ecommerce.ShareModels.Menu;

public class SubMenuDto : BaseDto<int> {
    public int MenuItemId { get; set; }
    public MenuItemDto MenuItem { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}

public class CreateSubMenuDto {
    public int MenuItemId { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
}

public class UpdateSubMenuDto : BaseDto<int> {
    public int MenuItemId { get; set; }
    public string Title { get; set; }
    public int CategoryId { get; set; }
}