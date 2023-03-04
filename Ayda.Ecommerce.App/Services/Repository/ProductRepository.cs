using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.Domains.Ecommerce;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductComment;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;
using Ayda.Ecommerce.ShareModels.User;
using Ayda.Ecommerce.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class ProductRepository : IProductRepository {
    private readonly DataBaseContext _db;
    private IHostingEnvironment _environment;
    private IMapper _mapper;

    public ProductRepository(DataBaseContext db, IHostingEnvironment environment, IMapper mapper) {
        _db = db;
        _environment = environment;
        _mapper = mapper;
    }

    public ResultDto<GetForAdmin<ProductDto>> GetProductForAdmin(string? filterProduct, string? search = null, int pageSize = 100, int pageNumber = 1) {
        int rowCount = 0;
        var productList = _db.Products
            .Include(x => x.Category)
            .ThenInclude(x => x.ParentCategory)
            .ThenInclude(x => x.CategoryAttributes)
            .Include(x => x.ProductAttributes)
            .Include(x => x.ProductColors)
            .Include(x => x.ProductImages)
            .Include(x => x.ProductComments)
            .ThenInclude(x => x.ApplicationUser)
            .ToPaged(pageNumber, pageSize, out rowCount).AsQueryable();
        if (!string.IsNullOrWhiteSpace(search)) {
            productList = productList.Where(x =>
                x.Name.Contains(search) || x.Category.Name.Contains(search)).AsQueryable();
        }

        if (!string.IsNullOrWhiteSpace(filterProduct)) {
            switch (filterProduct) {
                case "not-allow-comment": {
                        productList = productList.Where(x => x.AllowCustomerComment == false);
                        break;
                    }
                case "not-is-show": {
                        productList = productList.Where(x => x.IsShow == false);
                        break;
                    }
                case "show-in-home": {
                        productList = productList.Where(x => x.ShowOnHomepage == true);
                        break;
                    }
                case "is-sotial": {
                        productList = productList.Where(x => x.IsSotialProduct == true);
                        break;
                    }
                case "is-discount": {
                        productList = productList.Where(x => x.IsDiscount == true);
                        break;
                    }
            }
        }
        var mappToDto = _mapper.Map<IEnumerable<ProductDto>>(productList);
        return new ResultDto<GetForAdmin<ProductDto>>() {

            Data = new GetForAdmin<ProductDto>() {
                EntityDto = mappToDto.ToList(),
                CurrentPage = pageNumber,
                PageSize = pageSize,
                RowCount = rowCount
            },
            IsSuccess = true,
        };
    }

    public async Task<ResultDto<ProductDto>> GetByIdAsync(int id) {
        var product =  _db.Products
            .Include(x => x.Category)
            .ThenInclude(x => x.CategoryAttributes)
            .Include(x => x.ProductAttributes)
            .Include(x => x.ProductColors)
            .Include(x => x.ProductImages)
            .Include(x => x.ProductComments)
            .ThenInclude(x => x.ApplicationUser)
            .Where(c => c.Id == id);
        if (product == null) {
            return new ResultDto<ProductDto> {
                Message = "محصول یافت نشد",
                Data = null,
                IsSuccess = false,
            };
        }

        var mappToDto =await  product.Select(p => new ProductDto() {
            Category = new CategoryDto() {
                Name = p.Category.Name,
                CreatedDate = p.Category.CreatedDate,
                Description = p.Category.Description,
                LogoPath = p.Category.LogoPath
            },
            Id = p.Id,
            IsDiscount = p.IsDiscount,
            IsSotialProduct = p.IsSotialProduct,
            ShowOnHomepage = p.ShowOnHomepage,
            CreatedDate = p.CreatedDate,
            AllowCustomerComment = p.AllowCustomerComment,
            CategoryId = p.CategoryId,
            Count = p.Count,
            DiscountLableText = p.DiscountLableText,
            FullDescription = p.FullDescription,
            Height = p.Height,
            ImageCoverPath = p.ImageCoverPath,
            IsShow = p.IsShow,
            Length = p.Length,
            Name = p.Name,
            ProductAttributes = p.ProductAttributes.Select(a => new ProductAttributeDto() {
                Id = a.Id,
                UpdatedDate = a.UpdatedDate,
                IsShow = a.IsShow,
                CreatedDate = a.CreatedDate,
                AttributeId = a.AttributeId,
                AttributeValue = a.AttributeValue,
                CategoryAttribute = new CategoryAttributeDto() {
                    IsShow = a.CategoryAttribute.IsShow,
                    CreatedDate = a.CategoryAttribute.CreatedDate,
                    CategoryId = a.CategoryAttribute.CategoryId,
                    Id = a.CategoryAttribute.Id,
                    Name = a.CategoryAttribute.Name,


                },
            }).ToList(),
            UpdatedDate = p.UpdatedDate,
            ProductColors = p.ProductColors.Select(c => new ProductColorDto {
                IsShow = c.IsShow,
                CreatedDate = c.CreatedDate,
                Id = c.Id,
                UpdatedDate = c.UpdatedDate,
                ColorHex = c.ColorHex,
                ColorName = c.ColorName,
                ProductId = c.ProductId
            }).ToList(),
            ProductImages = p.ProductImages.Select(i => new ProductImageDto {
                Id = i.Id,
                CreatedDate = i.CreatedDate,
                IsShow = i.IsShow,
                AltTagAttribute = i.AltTagAttribute,
                UpdatedDate = i.UpdatedDate,
                ProductId = i.ProductId,
                ImagePath = i.ImagePath,
                TitleTagAttribute = i.TitleTagAttribute
            }).ToList(),
            ProductComments = p.ProductComments.Select(c => new ProductCommentDto() {
                Id = c.Id,
                CreatedDate = c.CreatedDate,
                IsShow = c.IsShow,
                CommentText = c.CommentText,
                UpdatedDate = c.UpdatedDate,
                ProductId = c.ProductId,
                ApplicationUser = new ApplicationUserDto {
                    FName = c.ApplicationUser.FName,
                    LName = c.ApplicationUser.LName,
                },
                UserId = c.UserId
            }).ToList(),
            Price = p.Price,
            Rate = p.Rate,
            ShortDescription = p.ShortDescription,
            ShowCount = p.ShowCount,
            Weight = p.Weight,
            Width = p.Width,
        }).FirstOrDefaultAsync();
        return new ResultDto<ProductDto> {
            Data = mappToDto,
            IsSuccess = true
        };
    }

    public async Task<ResultDto> AddAsync(CreateProductDto productDto) {
        var mappToProduct = _mapper.Map<Product>(productDto);
        if (productDto.Image != null) {
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(productDto.Image, $@"\images\product\");
            mappToProduct.ImageCoverPath = uploadedResult.FileNameAddress;
        }

        try {
            await _db.Products.AddAsync(mappToProduct);
            await _db.SaveChangesAsync();
            return new ResultDto {
                Message = $"محصول جدید با عنوان {productDto.Name} به لیست محصولات اضافه گردید",
                IsSuccess = true
            };
        } catch (Exception e) {
            return new ResultDto {
                Message = e.Message,
                IsSuccess = false
            };
        }
    }

    public async Task<ResultDto> UpdateAsync(UpdateProductDto productDto) {
        var product = await _db.Products
            .Include(x => x.Category)
            .FirstOrDefaultAsync(c => c.Id == productDto.Id);
        if (product == null) {
            return new ResultDto() {
                Message = "محصول یافت نشد",
                IsSuccess = false,
            };
        }

        if (productDto.Image != null) {
            if (!string.IsNullOrWhiteSpace(product.ImageCoverPath)) {
                string webRootPath = _environment.WebRootPath;
                var oldImagePath = Path.Combine(webRootPath, product.ImageCoverPath.TrimStart('\\'));
                DeleteFile.DeleteFileFromRoot(oldImagePath);
            }
            UploadHelper uploadObj = new UploadHelper(_environment);
            var uploadedResult = uploadObj.UploadFile(productDto.Image, $@"\images\product\");
            product.ImageCoverPath = uploadedResult.FileNameAddress;
        }

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.ShortDescription = productDto.ShortDescription;
        product.FullDescription = productDto.FullDescription;
        product.ShowCount = productDto.ShowCount;
        product.IsSotialProduct = productDto.IsSotialProduct;
        product.IsDiscount = productDto.IsDiscount;
        product.DiscountLableText = productDto.DiscountLableText;
        product.ShowOnHomepage = productDto.ShowOnHomepage;
        product.AllowCustomerComment = productDto.AllowCustomerComment;
        product.Count = productDto.Count;
        product.Rate = productDto.Rate;
        product.Weight = productDto.Weight;
        product.Length = productDto.Length;
        product.Width = productDto.Width;
        product.Height = productDto.Height;
        product.CategoryId = productDto.CategoryId;
        product.UpdatedDate = DateTime.Now;
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = $"محصول {product.Name} با موفقیت ویرایش شد"
        };

    }

    public async Task<ResultDto> RemoveAsync(int id) {
        var product = await _db.Products
            .Include(x => x.Category)
            .ThenInclude(x => x.CategoryAttributes)
            .Include(x => x.ProductAttributes)
            .Include(x => x.ProductColors)
            .Include(x => x.ProductImages)
            .Include(x => x.ProductComments)
            .ThenInclude(x => x.ApplicationUser)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (product == null) {
            return new ResultDto() {
                Message = "محصول یافت نشد",
                IsSuccess = false,
            };
        }

        if (product.ProductImages.Count > 0) {
            return new ResultDto() {
                Message = "ابتدا گالری محصول را حذف کنید و مجدد تلاش کنید",
                IsSuccess = false,
            };
        }
        if (product.ProductAttributes.Count > 0) {
            return new ResultDto() {
                Message = "ابتدا مشخصات محصول را حذف کنید و مجدد تلاش کنید",
                IsSuccess = false,
            };
        }
        if (product.ProductColors.Count > 0) {
            return new ResultDto() {
                Message = "ابتدا لیست رنگهای محصول را حذف کنید و مجدد تلاش کنید",
                IsSuccess = false,
            };
        }

        _db.Remove(product);
        await _db.SaveChangesAsync();
        return new ResultDto() {
            IsSuccess = true,
            Message = "حذف محصول با موفقیت به اتمام رسید"
        };
    }

    public async Task<ResultDto> AddAttributeAsync(CreateProductAttributeDto productAttribute) {
        var mappToProductAttrinute = _mapper.Map<ProductAttribute>(productAttribute);
        try {
            await _db.ProductAttributes.AddAsync(mappToProductAttrinute);
            await _db.SaveChangesAsync();
            return new ResultDto {
                Message = $"مشخصه با موفقیت به لیست مشخصات محصول اضافه شد",
                IsSuccess = true
            };
        } catch (Exception e) {
            return new ResultDto {
                Message = e.Message,
                IsSuccess = false
            };
        }
    }

    public async Task<ResultDto> AddColorAsync(CreateProductColorDto productColor) {
        var mappToproductColor = _mapper.Map<ProductColor>(productColor);
        try {
            await _db.ProductColors.AddAsync(mappToproductColor);
            await _db.SaveChangesAsync();
            return new ResultDto {
                Message = $"رنگ با موفقیت به لیست رنگهای محصول اضافه شد",
                IsSuccess = true
            };
        } catch (Exception e) {
            return new ResultDto {
                Message = e.Message,
                IsSuccess = false
            };
        }
    }

    public async Task<ResultDto> AddImagesAsync(CreateProductImageDto ProductImages) {
        var mappToproductImage = _mapper.Map<ProductImage>(ProductImages);
        UploadHelper uploadObj = new UploadHelper(_environment);
        var uploadedResult = uploadObj.UploadFile(ProductImages.Image, $@"\images\product\gallery\");
        mappToproductImage.ImagePath = uploadedResult.FileNameAddress;
        try {
            await _db.ProductImages.AddAsync(mappToproductImage);
            await _db.SaveChangesAsync();
            return new ResultDto {
                Message = $"تصویر با موفقیت به گالری  محصول اضافه شد",
                IsSuccess = true
            };
        } catch (Exception e) {
            return new ResultDto {
                Message = e.Message,
                IsSuccess = false
            };
        }
    }

    public async Task<ResultDto> YesOrNoIsShowProductAsync(int id) {
        var product = await _db.Products.FindAsync(id);
        if (product == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }
        product.IsShow = !product.IsShow;
        product.UpdatedDate = DateTime.Now;
        string isShowstate = product.IsShow == true ? "محصول از وضعیت مخفی به آشکار تغییر کد" : "محصول از وضعیت آشکار به مخفی تغییر کد";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = isShowstate
        };
    }

    public async Task<ResultDto> YesOrNoProductDiscountAsync(int id, string? DiscountLableText) {
        var product = await _db.Products.FindAsync(id);
        if (product == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }
        product.IsDiscount = !product.IsDiscount;
        if (product.IsDiscount) {
            product.DiscountLableText = DiscountLableText;
        }
        product.UpdatedDate = DateTime.Now;
        string isDiscount = product.IsDiscount == true ? "محصول دارای تخفیف است" : "محصول دارای تخفیف نیست";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = isDiscount
        };
    }

    public async Task<ResultDto> YesOrNoProductIsSotialAsync(int id) {
        var product = await _db.Products.FindAsync(id);
        if (product == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }
        product.IsSotialProduct = !product.IsSotialProduct;
        product.UpdatedDate = DateTime.Now;
        string IsSotial = product.IsSotialProduct == true ? "محصول به محصول ویژه تغییر کرد" : "محصول به محصول معمولی تغغیر کرد";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = IsSotial
        };
    }

    public async Task<ResultDto> ShowOrHideProductInHomePageAsync(int id) {
        var product = await _db.Products.FindAsync(id);
        if (product == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }
        product.ShowOnHomepage = !product.ShowOnHomepage;
        product.UpdatedDate = DateTime.Now;
        string showInHome = product.ShowOnHomepage == true ? "محصول در صفحه خانه نمایش داده میشود" : "نمایش محصول در خانه متوقف شد";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = showInHome
        };
    }

    public async Task<ResultDto> AllowOrNotAllowCommentAsync(int id) {
        var product = await _db.Products.FindAsync(id);
        if (product == null) {
            return new ResultDto {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }
        product.AllowCustomerComment = !product.AllowCustomerComment;
        product.UpdatedDate = DateTime.Now;
        string showInHome = product.AllowCustomerComment == true ? "محصول اجازه نظر دادن دارد" : "محصول اجازه نظر دادن ندارد";
        await _db.SaveChangesAsync();
        return new ResultDto {
            IsSuccess = true,
            Message = showInHome
        };
    }

    public async Task<ResultDto<IEnumerable<CategoryAttributeDto>>> GetAttribute(int categoryId) {
        var category = await _db.Categories.FindAsync(categoryId);
        var attribute =await _db.CategoryAttributes
            .Include(x => x.Category)
            .Include(x => x.ProductAttributes)
            .Where(w => w.CategoryId == categoryId).ToListAsync();
        if (attribute == null) {
            return new ResultDto<IEnumerable<CategoryAttributeDto>>() {
                Data = null,
                IsSuccess = false,
                Message = $"مشخصهای برای دسته {category.Name} ثبت نشده لطفا مشخصات دسته را ثبت کنید"
            };
        }
        
        return new ResultDto<IEnumerable<CategoryAttributeDto>> {
            IsSuccess = true,
            Data = _mapper.Map<IEnumerable<CategoryAttributeDto>>(attribute)
        };
    }
}