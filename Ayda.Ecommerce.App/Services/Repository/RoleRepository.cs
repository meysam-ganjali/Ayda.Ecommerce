using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.User;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Role;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class RoleRepository:IRoleRepository
{
    private readonly DataBaseContext _db;
    private IMapper _mapper;

    public RoleRepository(DataBaseContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto> AddAsync(CreateRoleDto role) {
        if (string.IsNullOrWhiteSpace(role.Name)) {
            return new ResultDto {
                IsSuccess = false,
                Message = "پارامتر ارسالی نامعتبر است"
            };
        }

        var roleEntity = _mapper.Map<Role>(role);
        await _db.Roles.AddAsync(roleEntity);
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "نقش با موفقیت به سیستم اضافه گردید"
        };
    }


    public async Task<ResultDto> RemoveAsync(int id) {
        if (id == null || id <= 0) {
            return new ResultDto {
                IsSuccess = false,
                Message = "پارامتر ارسالی نامعتبر است"
            };
        }
        var role = await _db.Roles
            .Include(x => x.ApplicationUsers)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (role.ApplicationUsers.Count > 0 || role.ApplicationUsers.Any()) {
            return new ResultDto {
                IsSuccess = false,
                Message = "این نقش قابل حذف نیست زیرا کاربرانی با این نقش درسیستم فعالیت می کنند"
            };
        }

        _db.Roles.Remove(role);
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = "نقش حذف گردید"
        };
    }

    public async Task<ResultDto<RoleDto>> GetByAsync(string name) {
        var role = await _db.Roles
            .FirstOrDefaultAsync(x => x.Name.Equals(name));
        if (role == null) {
            return new ResultDto<RoleDto>() {
                IsSuccess = false,
                Message = "نقشی با این نام یافت نشد",
                Data = null
            };
        }

        return new ResultDto<RoleDto> {
            Data = _mapper.Map<RoleDto>(role),
            IsSuccess = true,
        };
    }

    public async Task<ResultDto<RoleDto>> GetByAsync(int id) {
        var role = await _db.Roles
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (role == null) {
            return new ResultDto<RoleDto>() {
                IsSuccess = false,
                Message = "نقشی با این کد یافت نشد",
                Data = null
            };
        }

        return new ResultDto<RoleDto> {
            Data = _mapper.Map<RoleDto>(role),
            IsSuccess = true,
        };
    }

    public async Task<ResultDto<IEnumerable<RoleDto>>> GetAllAsync() {
        var roles = await _db.Roles
            .Include(x => x.ApplicationUsers)
            .ToListAsync();
        return new ResultDto<IEnumerable<RoleDto>>() {
            Data = _mapper.Map<IEnumerable<RoleDto>>(roles),
            IsSuccess = true,
        };
    }
}