using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.App.Contract.IRepository;

public interface IProductRepository
{
    ResultDto<GetForAdmin<ProductDto>> GetProductForAdmin(string? filterProduct, string? search = null, int pageSize = 100, int pageNumber = 1);
    Task<ResultDto<ProductDto>> GetByIdAsync(int id);
    Task<ResultDto> AddAsync(CreateProductDto productDto);
    Task<ResultDto> UpdateAsync(UpdateProductDto productDto);
    Task<ResultDto> RemoveAsync(int id);
    Task<ResultDto> AddAttributeAsync(CreateProductAttributeDto productAttribute);
    Task<ResultDto> AddColorAsync(CreateProductColorDto productColor);
    Task<ResultDto> AddImagesAsync(CreateProductImageDto ProductImages);
    Task<ResultDto> YesOrNoIsShowProductAsync(int id);
    Task<ResultDto> YesOrNoProductDiscountAsync(int id,string? DiscountLableText);
    Task<ResultDto> YesOrNoProductIsSotialAsync(int id);
    Task<ResultDto> ShowOrHideProductInHomePageAsync(int id);
    Task<ResultDto> AllowOrNotAllowCommentAsync(int id);
}