using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;
using Ayda.Ecommerce.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class CategoryRepository : ICategoryRepository {
    private readonly DataBaseContext _db;
    private IHostingEnvironment _environment;
    private IMapper _mapper;

    public CategoryRepository(DataBaseContext db, IHostingEnvironment environment, IMapper mapper) {
        _db = db;
        _environment = environment;
        _mapper = mapper;
    }

    public async Task<ResultDto> AddAsync(CreateCategoryDto categoryDto) {
        var categoy = _mapper.Map<Category>(categoryDto);
        if (categoryDto.Image != null) {
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(categoryDto.Image, $@"\images\category_logo\");
            categoy.LogoPath = uploadedResult.FileNameAddress;
        }

        try {
            await _db.Categories.AddAsync(categoy);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = $"دسته بندی با عنوان {categoy.Name} به فروشگاه اضافه شد"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto> RemoveAsync(int id) {
        var category = await _db.Categories.Include(x => x.CategoryAttributes)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (category == null) {
            return new ResultDto {
                Message = "دسته بندی یافت نشد",
                IsSuccess = false
            };
        }

        if (category.CategoryAttributes.Count > 0) {
            return new ResultDto {
                Message = "ابتدا مشخصات دسته بندی را حذف کنید و بعد مجدد امتحان کنید",
                IsSuccess = false
            };
        }
        if (!string.IsNullOrWhiteSpace(category.LogoPath)) {
            string webRootPath = _environment.WebRootPath;
            var oldImagePath = Path.Combine(webRootPath, category.LogoPath.TrimStart('\\'));
            DeleteFile.DeleteFileFromRoot(oldImagePath);
        }

        _db.Categories.Remove(category);
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "دسته بندی حذف گردید",
            IsSuccess = true
        };
    }

    public async Task<ResultDto> UpdateAsync(UpdateCategoryDto categoryDto) {
        var category = await _db.Categories.FindAsync(categoryDto.Id);
        if (category == null) {
            return new ResultDto {
                Message = "دسته بندی یافت نشد",
                IsSuccess = false
            };
        }
        if (categoryDto.Image != null) {
            if (!string.IsNullOrWhiteSpace(category.LogoPath)) {
                string webRootPath = _environment.WebRootPath;
                var oldImagePath = Path.Combine(webRootPath, category.LogoPath.TrimStart('\\'));
                DeleteFile.DeleteFileFromRoot(oldImagePath);
            }
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(categoryDto.Image, $@"\images\category_logo\");
            category.LogoPath = uploadedResult.FileNameAddress;
        }

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedDate = DateTime.Now;
        category.ParentCategoryId = categoryDto.ParentCategoryId;
        await _db.SaveChangesAsync();
        return new ResultDto {
            Message = "بروزرسانی دسته بندی موفقیت آمیز بود",
            IsSuccess = true
        };

    }

    public async Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync(int? id) {
        IEnumerable<Category> categories;

        if (id > 0 || id != null) {
            categories = await _db.Categories
                .Include(x => x.SubCategories)
                .Include(x => x.CategoryAttributes)
                .Where(x => x.ParentCategoryId == id).ToListAsync();
        } else {
            categories = await _db.Categories
                .Include(x => x.SubCategories)
                .Include(x => x.CategoryAttributes)
                .Where(x => x.ParentCategoryId == null)
                .ToListAsync();
        }
        return new ResultDto<IEnumerable<CategoryDto>> {
            IsSuccess = true,
            Data = _mapper.Map<IEnumerable<CategoryDto>>(categories)
        };
    }
    public async Task<ResultDto<IEnumerable<CategoryDto>>> GetAllAsync() {
        IEnumerable<Category> categories;


        categories = await _db.Categories
            .Include(x => x.SubCategories)
            .Include(x => x.CategoryAttributes)
            .Where(x => x.ParentCategoryId != null).ToListAsync();

        return new ResultDto<IEnumerable<CategoryDto>> {
            IsSuccess = true,
            Data = _mapper.Map<IEnumerable<CategoryDto>>(categories)
        };
    }

    public async Task<ResultDto<CategoryDto>> GetByIdAsync(int id) {
        var category = await _db.Categories.FindAsync(id);
        if (category == null) {
            return new ResultDto<CategoryDto> {
                Message = "دسته بندی یافت نشد",
                IsSuccess = false,
                Data = null
            };
        }

        return new ResultDto<CategoryDto> {
            Data = _mapper.Map<CategoryDto>(category),
            IsSuccess = true
        };
    }

    public async Task<ResultDto> AddAtributeAsync(CreateCategoryAttributeDto attr) {
        var cat = await GetByIdAsync(attr.CategoryId);
        var mappToCategoryAttribute = _mapper.Map<CategoryAttribute>(attr);
        try {
            await _db.CategoryAttributes.AddAsync(mappToCategoryAttribute);
            await _db.SaveChangesAsync();
            return new ResultDto {
                IsSuccess = true,
                Message = $"مشخصع با عنوان {attr.Name} به لیست مشخصات دسته بندی {cat.Data.Name} اضافه شد"
            };
        } catch (Exception e) {
            return new ResultDto {
                IsSuccess = false,
                Message = e.Message
            };
        }
    }

    public async Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAllCategoryAttributeAsync(int childCategoryId) {
        var categoryAttribute = await _db.CategoryAttributes
            .Include(x => x.Category)
            .Where(x => x.CategoryId == childCategoryId)
            .ToListAsync();
        if (categoryAttribute == null || !categoryAttribute.Any()) {
            return new ResultDto<IEnumerable<CategoryAttributeDto>>() {
                Data = null,
                IsSuccess = false,
                Message = "مشخصه ای برای این دسته ثبت نشده است"
            };
        }

        return new ResultDto<IEnumerable<CategoryAttributeDto>> {
            Data = _mapper.Map<IEnumerable<CategoryAttributeDto>>(categoryAttribute), IsSuccess = true
        };
    }
}