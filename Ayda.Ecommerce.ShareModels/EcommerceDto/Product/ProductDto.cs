using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductAttribute;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductColor;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductComment;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductImage;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product;

public class ProductDto:BaseDto<int>
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string? ImageCoverPath { get; set; }
    public string ShortDescription { get; set; }
    public string? FullDescription { get; set; }
    public int ShowCount { get; set; }
    public bool IsSotialProduct { get; set; }
    public bool IsDiscount { get; set; } = false;
    public string DiscountLableText { get; set; }
    public bool ShowOnHomepage { get; set; }
    public bool AllowCustomerComment { get; set; }
    public int Count { get; set; }
    public int Rate { get; set; }
    public int? Weight { get; set; }
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    //Relation
    public int CategoryId { get; set; }
    public  CategoryDto Category { get; set; }
    public List<ProductAttributeDto> ProductAttributes { get; set; }
    public List<ProductImageDto> ProductImages { get; set; }
    public List<ProductColorDto> ProductColors { get; set; }
    public List<ProductCommentDto> ProductComments { get; set; }
}