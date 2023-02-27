using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;
using Ayda.Ecommerce.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Ayda.Ecommerce.Domains.User;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.ShareModels.EcommerceDto;

namespace Ayda.Ecommerce.App.Services.Repository;

public class AuthenticationRepository : IAuthenticationRepository {
    private readonly DataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public AuthenticationRepository(DataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }
    public async Task<ResultDto<AuthResultDto>> LoginAsync(LoginDto loginDto) {
        if (string.IsNullOrWhiteSpace(loginDto.UserName) || string.IsNullOrWhiteSpace(loginDto.Password)) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "نام کاربری و رمز عبور را وارد نمایید",
            };
        }

        var user = await _db.ApplicationUsers
            .Include(p => p.Role)
            .FirstOrDefaultAsync(p => (p.UserPhone.Equals(loginDto.UserName) || p.Email.Equals(loginDto.UserName))
                                      && p.IsActive == true);

        if (user == null) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "کاربری با این ایمیل در سایت فروشگاه  ثبت نام نکرده است",
            };
        }
        var passwordHasher = new PasswordHasher();
        bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, loginDto.Password);
        if (resultVerifyPassword == false) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "رمز وارد شده اشتباه است!",
            };
        }

        user.LastLoginDateTime = DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto<AuthResultDto>() {
            Data = new AuthResultDto {
                CellPhone = user.UserPhone,
                Email = user.Email,
                FullName = $"{user.FName} {user.LName}",
                Id = user.Id,
                RoleName = user.Role.Name
            },
            IsSuccess = true,
            Message = "ورود به سایت با موفقیت انجام شد",
        };
    }

    public async Task<ResultDto> RegisterForAdminAsync(CreateApplicationUserDto userDto) {
        try {
            if (string.IsNullOrWhiteSpace(userDto.Email)) {

                return new ResultDto() {
                    IsSuccess = false,
                    Message = "پست الکترونیک را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(userDto.FName)) {
                return new ResultDto() {
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(userDto.LName)) {
                return new ResultDto() {
                    IsSuccess = false,
                    Message = "نام خانوادگی را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(userDto.Password)) {
                return new ResultDto() {
                    IsSuccess = false,
                    Message = "رمز عبور را وارد نمایید"
                };
            }
            if (userDto.Password != userDto.ConfirmPassword) {
                return new ResultDto() {
                    IsSuccess = false,
                    Message = "رمز عبور و تکرار آن برابر نیست"
                };
            }
            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(userDto.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success) {
                return new ResultDto() {
                    IsSuccess = false,
                    Message = "ایمیل خودرا به درستی وارد نمایید"
                };
            }


            var passwordHasher = new PasswordHasher();
            var hashedPassword = passwordHasher.HashPassword(userDto.Password);
            var user = _mapper.Map<ApplicationUser>(userDto);
            user.Password = hashedPassword;
            if (userDto.Image != null) {
                UploadHelper uploadObj = new UploadHelper(_environment);
                var uploadedResult = uploadObj.UploadFile(userDto.Image, $@"\images\userAvatar\");
                user.Avatar = uploadedResult.FileNameAddress;
            }
            await _db.ApplicationUsers.AddAsync(user);

            await _db.SaveChangesAsync();

            return new ResultDto() {
                IsSuccess = true,
                Message = "ثبت نام کاربر انجام شد",
            };
        } catch (Exception) {
            return new ResultDto() {
                IsSuccess = false,
                Message = "ثبت نام انجام نشد !"
            };
        }
    }

    public async Task<ResultDto<AuthResultDto>> RegisterAsync(RegisterApplicationUserDto userDto) {
        try {
            if (string.IsNullOrWhiteSpace(userDto.Email)) {

                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "پست الکترونیک را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(userDto.FName)) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(userDto.LName)) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "نام خانوادگی را وارد نمایید"
                };
            }
            if (string.IsNullOrWhiteSpace(userDto.Password)) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "رمز عبور را وارد نمایید"
                };
            }
            if (userDto.Password != userDto.ConfirmPassword) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "رمز عبور و تکرار آن برابر نیست"
                };
            }
            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
            var match = Regex.Match(userDto.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success) {
                return new ResultDto<AuthResultDto>() {
                    Data = null,
                    IsSuccess = false,
                    Message = "ایمیل خودرا به درستی وارد نمایید"
                };
            }


            var passwordHasher = new PasswordHasher();
            var hashedPassword = passwordHasher.HashPassword(userDto.Password);
            var user = _mapper.Map<ApplicationUser>(userDto);
            if (userDto.Image != null) {
                UploadHelper uploadObj = new UploadHelper(_environment);
                var uploadedResult = uploadObj.UploadFile(userDto.Image, $@"\images\userAvatar\");
                user.Avatar = uploadedResult.FileNameAddress;
            }
            user.OrganizationEmail = userDto.Email.ToUpper();
            user.Password = hashedPassword;
            user.EmailConfirm = false;
            user.RoleId = 2;
            user.PhoneConfirm = false;
            user.IsLocked = false;
            user.IsActive = false;
            user.Gender = Ayda.Ecommerce.Domains.User.Gender.MAN;
            await _db.ApplicationUsers.AddAsync(user);

            await _db.SaveChangesAsync();

            return new ResultDto<AuthResultDto>() {
                Data = new AuthResultDto {
                    CellPhone = user.UserPhone,
                    Email = user.Email,
                    FullName = $"{user.FName} {user.LName}",
                    Id = user.Id,
                },
                IsSuccess = true,
                Message = "ثبت نام کاربر انجام شد",
            };
        } catch (Exception) {
            return new ResultDto<AuthResultDto>() {
                Data = null,
                IsSuccess = false,
                Message = "ثبت نام انجام نشد !"
            };
        }
    }
}