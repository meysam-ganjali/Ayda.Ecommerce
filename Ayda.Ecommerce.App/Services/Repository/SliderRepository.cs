using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.Domains.Slider;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.Slider;
using Ayda.Ecommerce.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class SliderRepository : ISliderRepository {
    private readonly DataBaseContext _db;
    private IMapper _mapper;
    private IHostingEnvironment _environment;

    public SliderRepository(DataBaseContext db, IMapper mapper, IHostingEnvironment environment) {
        _db = db;
        _mapper = mapper;
        _environment = environment;
    }
    public async Task<ResultDto> AddAsync(CreateSliderDto sliderDto) {
        var slider = _mapper.Map<Slider>(sliderDto);
        if (sliderDto.Image == null) {
            return new ResultDto() {
                IsSuccess = false,
                Message = "تصویر برای اسلایدر انتخاب نکرده اید"
            };
        }
        UploadHelper uploadObj = new UploadHelper(_environment);
        var uploadedResult = uploadObj.UploadFile(sliderDto.Image, $@"\images\slider\");
        slider.ImagePath = uploadedResult.FileNameAddress;
        try {
            await _db.Sliders.AddAsync(slider);
            await _db.SaveChangesAsync();
            return new ResultDto() {
                IsSuccess = true,
                Message = "اسلایدر با موفقیت ثبت شد"
            };
        } catch (Exception e) {
            return new ResultDto() {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto> UpdateAsync(UpdateSliderDto sliderDto) {
        var slider = await _db.Sliders.FindAsync(sliderDto.Id);
        if (slider == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "اسلایدر یافت نشد"
            };
        }
        if (sliderDto.Image != null) {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, slider.ImagePath.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(sliderDto.Image, $@"\images\slider\");
            slider.ImagePath = uploadedResult.FileNameAddress;
        }

        slider.Description = sliderDto.Description;
        slider.PossitionId = sliderDto.PossitionId;
        slider.Link = sliderDto.Link;
        slider.Title = sliderDto.Title;
        slider.UpdatedDate = DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "بروزرسانی اسلایدر با موفقیت به اتمام رسید",
            IsSuccess = true
        };
    }

    public async Task<ResultDto<IEnumerable<SliderDto>>> GetAllAsync() {
        var sliders = await _db.Sliders
            .Include(x => x.Possition)
            .ToListAsync();
        if (sliders.Any() || sliders.Count > 0) {
            return new ResultDto<IEnumerable<SliderDto>> {
                Data = _mapper.Map<IEnumerable<SliderDto>>(sliders),
                IsSuccess = true
            };
        } else {
            return new ResultDto<IEnumerable<SliderDto>> {
                Data = null,
                IsSuccess = false,
                Message = "اسلایدری برای نمایش وجود ندارد"
            };
        }
    }

    public async Task<ResultDto<SliderDto>> GetByIdAsync(int id) {
        var slider = await _db.Sliders
            .Include(x => x.Possition)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (slider != null) {
            return new ResultDto<SliderDto> {
                Data = _mapper.Map<SliderDto>(slider),
                IsSuccess = true
            };
        } else {
            return new ResultDto<SliderDto> {
                Data = null,
                IsSuccess = false,
                Message = "اسلایدریافت نشد"
            };
        }
    }

    public async Task<ResultDto> RemoveAsync(int id) {
        var slider = await _db.Sliders.FindAsync(id);
        if (slider == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "اسلایدر یافت نشد"
            };
        }
        try {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, slider.ImagePath.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);
            _db.Sliders.Remove(slider);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = "اسلایدر از سیستم حذف گردید"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto> ChangeIsShow(int id) {
        var slider = await _db.Sliders.FindAsync(id);
        if (slider == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "اسلایدر یافت نشد"
            };
        }
        slider.IsShow = !slider.IsShow;
        slider.UpdatedDate = DateTime.Now;
        string isShowstate = slider.IsShow == true ? "اسلایدر از وضعیت مخفی به آشکار تغییر کد" : "اسلایدر از وضعیت آشکار به مخفی تغییر کد";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = isShowstate
        };
    }
}