namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;

public class CreateCategoryAttributeDto
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public bool IsShow { get; set; } = true;
}