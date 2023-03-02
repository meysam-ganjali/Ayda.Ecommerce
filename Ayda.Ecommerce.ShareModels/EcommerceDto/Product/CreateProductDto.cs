using Microsoft.AspNetCore.Http;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product;

public class CreateProductDto
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string? ImageCoverPath { get; set; }
    public IFormFile Image { get; set; }
    public string ShortDescription { get; set; }
    public string? FullDescription { get; set; }
    public int ShowCount { get; set; }
    public bool IsSotialProduct { get; set; }
    public bool IsDiscount { get; set; } = false;
    public string DiscountLableText { get; set; }
    public bool ShowOnHomepage { get; set; }
    public bool AllowCustomerComment { get; set; }
    public bool IsShow { get; set; }
    public int Count { get; set; }
    public int Rate { get; set; }
    public int? Weight { get; set; }
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    //Relation
    public int CategoryId { get; set; }//
}