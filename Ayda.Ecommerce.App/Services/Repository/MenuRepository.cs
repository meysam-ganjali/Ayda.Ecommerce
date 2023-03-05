using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Menu;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Menu;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class MenuRepository : IMenuRepository {
    private readonly DataBaseContext _db;
    private IMapper _mapper;

    public MenuRepository(DataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }
    public async Task<ResultDto> AddParentMenuAsync(CreateMenuItemDto parentDto) {
        var parentMenu = _mapper.Map<MenuItem>(parentDto);
        try {
            await _db.MenuItems.AddAsync(parentMenu);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = $"منوی پدر با عنوان {parentDto.Name} ثبت شد"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }

    }

    public async Task<ResultDto> UpdateParentMenuAsync(UpdateMenuItemDto parentDto) {
        var parentsMenu = await _db.MenuItems
            .Include(x => x.SubMenus)
            .FirstOrDefaultAsync(x => x.Id == parentDto.Id);
        if (parentsMenu == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "منوی یافت نشد"
            };
        }
        parentsMenu.Name = parentDto.Name;
        parentsMenu.UpdatedDate = DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "عملیات بروزرسانی منو با موفقیت با اتمام رسید"
        };
    }

    public async Task<ResultDto> DeleteParentMenuAsync(int id) {
        var parentsMenu = await _db.MenuItems
            .Include(x => x.SubMenus)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (parentsMenu == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "منوی یافت نشد"
            };
        }

        if (parentsMenu.SubMenus.Any() || parentsMenu.SubMenus.Count > 0) {
            return new ResultDto {
                IsSuccess = false,
                Message = "هشدار : منوی فوق دارای زیر مجموعه می باشد"
            };
        }

        _db.MenuItems.Remove(parentsMenu);
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "منوی فوق از دیتابیس حذف گردید",
            IsSuccess = true
        };
    }

    public async Task<ResultDto<IEnumerable<MenuItemDto>>> GetAllParentMenuAsync() {
        var parentsMenu = await _db.MenuItems
            .Include(x => x.SubMenus)
            .ThenInclude(x => x.Category)
            .ToListAsync();
        if (parentsMenu == null) {
            return new ResultDto<IEnumerable<MenuItemDto>> {
                Data = null,
                IsSuccess = false,
                Message = "منوی یافت نشد"
            };
        }
        return new ResultDto<IEnumerable<MenuItemDto>> {
            Data = _mapper.Map<IEnumerable<MenuItemDto>>(parentsMenu),
            IsSuccess = true,
        };

    }

    public async Task<ResultDto<MenuItemDto>> GetParentMenuAsync(int id) {
        var parentsMenu = await _db.MenuItems
            .Include(x => x.SubMenus)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (parentsMenu == null) {
            return new ResultDto<MenuItemDto>() {
                IsSuccess = false,
                Data = null,
                Message = "منوی یافت نشد"
            };
        }
        return new ResultDto<MenuItemDto> {
            Data = _mapper.Map<MenuItemDto>(parentsMenu),
            IsSuccess = true,
        };
    }

    public async Task<ResultDto> AddSubMenuAsync(CreateSubMenuDto subDto) {
        var subMenu = _mapper.Map<SubMenu>(subDto);
        try {
            await _db.SubMenus.AddAsync(subMenu);
            await _db.SaveChangesAsync();
            return new ResultDto {
                Message = "زیر منو با سیستم اضافهگردید",
                IsSuccess = true
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto> UpdateSubMenuAsync(UpdateSubMenuDto subDto) {
        var subMenu = await _db.SubMenus.FindAsync(subDto.Id);
        if (subMenu == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "زیر منو یافت نشد"
            };
        }
        subMenu.Title = subDto.Title;
        subMenu.CategoryId = subDto.CategoryId;
        subMenu.MenuItemId = subDto.MenuItemId;
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "عملیات بروزرسانی زیر منو با موفقیت به اتمام رسید"
        };
    }

    public async Task<ResultDto> DeleteSubMenuAsync(int id) {
        var subMenu = await _db.SubMenus.FindAsync(id);
        if (subMenu == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "زیر منو یافت نشد"
            };
        }

        try {
            _db.SubMenus.Remove(subMenu);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = "زیر منوی منتخب حذف شد"
            };
        } catch (Exception e) {
            return new ResultDto() {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto<IEnumerable<SubMenuDto>>> GetSubMenuByParentIdAsync(int parentId) {
        var subMenu = _db.SubMenus
            .Include(x => x.MenuItem)
            .Where(x => x.MenuItemId == parentId).ToListAsync();
        if (subMenu == null) {
            return new ResultDto<IEnumerable<SubMenuDto>> {
                IsSuccess = false,
                Message = "زیر منو یافت نشد",
                Data = null
            };

        }

        return new ResultDto<IEnumerable<SubMenuDto>> {
            Data = _mapper.Map<IEnumerable<SubMenuDto>>(subMenu),
            IsSuccess = true
        };
    }

    public async Task<ResultDto<SubMenuDto>> GetSubMenuAsync(int id) {
        var subMenu = await _db.SubMenus
            .FirstOrDefaultAsync(x => x.Id == id);
        if (subMenu == null) {
            return new ResultDto<SubMenuDto> {
                IsSuccess = false,
                Message = "زیر منو یافت نشد",
                Data = null
            };
        }

        return new ResultDto<SubMenuDto> {
            Data = _mapper.Map<SubMenuDto>(subMenu),
            IsSuccess = true,
        };
    }
}