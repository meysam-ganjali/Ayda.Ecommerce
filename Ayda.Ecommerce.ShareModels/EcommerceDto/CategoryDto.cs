using Ayda.Ecommerce.ShareModels.BaseModel;
using Microsoft.AspNetCore.Http;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto;

public class CategoryDto:BaseDto<int>
{
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public string? Description { get; set; }
    public int? ParentCategoryId { get; set; }
    public  CategoryDto ParentCategory { get; set; }
    //برای نمایش زیر دسته های هر گروه
    public  List<CategoryDto> SubCategories { get; set; }
    public  List<CategoryAttributeDto> CategoryAttributes { get; set; }
}

public class CreateCategoryDto
{
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public IFormFile? Image { get; set; }
    public string? Description { get; set; }
    public int? ParentCategoryId { get; set; }
}
public class UpdateCategoryDto{
    public int Id { get; set; }
    public IFormFile? Image { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public string? Description { get; set; }
    public int? ParentCategoryId { get; set; }
}