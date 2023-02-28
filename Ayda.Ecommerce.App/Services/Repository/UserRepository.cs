using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.Role;
using Ayda.Ecommerce.ShareModels.User;
using Ayda.Ecommerce.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ayda.Ecommerce.App.Services.Repository;

public class UserRepository : IUserRepository {
    private readonly DataBaseContext _db;
    private IHostingEnvironment _environment;
    private IMapper _mapper;

    public UserRepository(DataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }

    public ResultDto<UserForAdmin> GetUserForAdmin(string? filterUser, string? filter = null, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;
        var users = _db.ApplicationUsers
            .Include(x => x.Role)
            .ToPaged(pageNumber, pageSize, out rowCount).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter)) {
            users = users.Where(x =>
                x.FName.Contains(filter) || x.LName.Contains(filter) || x.Email.Contains(filter)).AsQueryable();
        }

        if (!string.IsNullOrWhiteSpace(filterUser)) {
            switch (filterUser) {
                case "Lock-users": {
                        users = users.Where(x => x.IsLocked == true);
                        break;
                    }
                case "deactive-users": {
                        users = users.Where(x => x.IsActive == false);
                        break;
                    }
                case "confirm-email": {
                        users = users.Where(x => x.EmailConfirm == false);
                        break;
                    }
                case "confirm-phone": {
                        users = users.Where(x => x.PhoneConfirm == false);
                        break;
                    }
            }
        }

        var mappToDto = users.Select(x => new ApplicationUserDto() {
            UserPhone = x.UserPhone,
            CreatedDate = x.CreatedDate,
            Email = x.Email,
            EmailConfirm = x.EmailConfirm,
            Avatar = x.Avatar,
            FName = x.FName,
            LName = x.LName,
            Id = x.Id,
            IsActive = x.IsActive,
            LastLoginDateTime = x.LastLoginDateTime,
            IsLocked = x.IsLocked,
            LockoutEndDate = x.LockoutEndDate,
            PhoneConfirm = x.PhoneConfirm,
            RoleId = x.RoleId,
            Role = new RoleDto {
                Id = x.Role.Id,
                Name = x.Role.Name
            },
            UpdatedDate = x.UpdatedDate
        }).ToList();
        return new ResultDto<UserForAdmin> {
            Data = new UserForAdmin() {
                UserDtos = mappToDto,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true,
        };
    }

    public async Task<ResultDto> LockOnLockAsync(long id) {
        var user = await _db.ApplicationUsers.FindAsync(id);
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }
        user.IsLocked = !user.IsLocked;
        user.LockoutEndDate = DateTime.Now;
        user.UpdatedDate = DateTime.Now;
        string userstate = user.IsLocked == true ? "قفل کاربر فعال شد" : "قفل کاربر باز شد";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = userstate
        };
    }

    public async Task<ResultDto> ActiveDeActiveAsync(long id) {
        var user = await _db.ApplicationUsers.FindAsync(id);
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }
        user.IsActive = !user.IsActive;
        user.UpdatedDate = DateTime.Now;
        string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = $"کاربر {userstate} شد"
        };
    }

    public async Task<ResultDto> ChangeRoleAsync(long UserId, int RoleId) {
        var role = await _db.Roles.FindAsync(RoleId);
        var user = await _db.ApplicationUsers.FindAsync(UserId);
        if (role == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "نقش یافت نشد"
            };
        }
        if (user == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }
        user.Role = role;
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = $"نقش کاربر {user.FName + " " + user.LName} به نقش {role.Name} تغییر کرد"
        };
    }

    public async Task<ResultDto<ApplicationUserDto>> GetUserByIdAsync(long id) {
        var userInDb = await _db.ApplicationUsers
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (userInDb == null) {
            return new ResultDto<ApplicationUserDto>() {
                Data = null,
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }

        ApplicationUserDto user = _mapper.Map<ApplicationUserDto>(userInDb);
        return new ResultDto<ApplicationUserDto>() {
            Data = user,
            IsSuccess = true,
        };
    }

    public async Task<ResultDto> AddOrChangeAvatar(long UserId, IFormFile avatar) {
        var userInDb = await _db.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == UserId);
        if (userInDb == null) {
            return new ResultDto() {
                IsSuccess = false,
                Message = "کاربر یافت نشد"
            };
        }

        if (!string.IsNullOrWhiteSpace(userInDb.Avatar)) {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, userInDb.Avatar.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);
        }
        UploadHelper uploadObj = new UploadHelper(_environment);
        var uploadedResult = uploadObj.UploadFile(avatar, $@"\images\user\");
        userInDb.Avatar = uploadedResult.FileNameAddress;
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "تصویر کاربر بروزرسانی شد",
            IsSuccess = true
        };
    }
}