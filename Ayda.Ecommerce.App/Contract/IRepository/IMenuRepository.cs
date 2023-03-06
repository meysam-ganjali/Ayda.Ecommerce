using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Menu;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IMenuRepository {
    Task<ResultDto> AddParentMenuAsync(CreateMenuItemDto parentDto);
    Task<ResultDto> UpdateParentMenuAsync(UpdateMenuItemDto parentDto);
    Task<ResultDto> DeleteParentMenuAsync(int id);
    Task<ResultDto<IEnumerable<MenuItemDto>>> GetAllParentMenuAsync();
    Task<ResultDto<MenuItemDto>> GetParentMenuAsync(int id);
    Task<ResultDto> ChangeShowForParent(int id);

    /*******************/
    Task<ResultDto> AddSubMenuAsync(CreateSubMenuDto subDto);
    Task<ResultDto> UpdateSubMenuAsync(UpdateSubMenuDto subDto);
    Task<ResultDto> DeleteSubMenuAsync(int id);
    Task<ResultDto<IEnumerable<SubMenuDto>>> GetSubMenuByParentIdAsync(int parentId);
    Task<ResultDto<SubMenuDto>> GetSubMenuAsync(int id);
    Task<ResultDto> ChangeShowForSub(int id);
}