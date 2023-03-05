using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Slider;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Slider;
using Ayda.Ecommerce.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class BannerRepository:IBannerRepository
{
    private readonly DataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public BannerRepository(DataBaseContext db, IMapper mapper, IHostingEnvironment environment)
    {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }
    public async Task<ResultDto> AddAsync(CreateBannerDto BannerDto) {
        var Banner = _mapper.Map<Banner>(BannerDto);
        if (BannerDto.Image == null) {
            return new ResultDto() {
                IsSuccess = false,
                Message = "تصویر برای بنر انتخاب نکرده اید"
            };
        }
        UploadHelper uploadObj = new UploadHelper(_environment);
        var uploadedResult = uploadObj.UploadFile(BannerDto.Image, $@"\images\banner\");
        Banner.ImagePath = uploadedResult.FileNameAddress;
        try {
            await _db.Banners.AddAsync(Banner);
            await _db.SaveChangesAsync();
            return new ResultDto() {
                IsSuccess = true,
                Message = "بنر با موفقیت ثبت شد"
            };
        } catch (Exception e) {
            return new ResultDto() {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto> UpdateAsync(UpdateBannerDto BannerDto) {
        var Banner = await _db.Banners.FindAsync(BannerDto.Id);
        if (Banner == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "بنر یافت نشد"
            };
        }
        if (BannerDto.Image != null) {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, Banner.ImagePath.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(BannerDto.Image, $@"\images\banner\");
            Banner.ImagePath = uploadedResult.FileNameAddress;
        }

        Banner.Description = BannerDto.Description;
        Banner.PossitionId = BannerDto.PossitionId;
        Banner.Link = BannerDto.Link;
        Banner.Title = BannerDto.Title;
        Banner.UpdatedDate = DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "بروزرسانی بنر با موفقیت به اتمام رسید",
            IsSuccess = true
        };
    }

    public async Task<ResultDto<IEnumerable<BannerDto>>> GetAllAsync() {
        var Banners = await _db.Banners
            .Include(x => x.Possition)
            .ToListAsync();
        if (Banners.Any() || Banners.Count > 0) {
            return new ResultDto<IEnumerable<BannerDto>> {
                Data = _mapper.Map<IEnumerable<BannerDto>>(Banners),
                IsSuccess = true
            };
        } else {
            return new ResultDto<IEnumerable<BannerDto>> {
                Data = null,
                IsSuccess = false,
                Message = "بنری برای نمایش وجود ندارد"
            };
        }
    }

    public async Task<ResultDto<BannerDto>> GetByIdAsync(int id) {
        var Banner = await _db.Banners
            .Include(x => x.Possition)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (Banner != null) {
            return new ResultDto<BannerDto> {
                Data = _mapper.Map<BannerDto>(Banner),
                IsSuccess = true
            };
        } else {
            return new ResultDto<BannerDto> {
                Data = null,
                IsSuccess = false,
                Message = "بنر یافت نشد"
            };
        }
    }

    public async Task<ResultDto> RemoveAsync(int id) {
        var Banner = await _db.Banners.FindAsync(id);
        if (Banner == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "بنر یافت نشد"
            };
        }
        try {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, Banner.ImagePath.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);
            _db.Banners.Remove(Banner);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = "بنر از سیستم حذف گردید"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto> ChangeIsShow(int id) {
        var Banner = await _db.Banners.FindAsync(id);
        if (Banner == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "بنر یافت نشد"
            };
        }
        Banner.IsShow = !Banner.IsShow;
        Banner.UpdatedDate = DateTime.Now;
        string isShowstate = Banner.IsShow == true ? "بنر از وضعیت مخفی به آشکار تغییر کد" : "بنر از وضعیت آشکار به مخفی تغییر کد";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = isShowstate
        };
    }
}