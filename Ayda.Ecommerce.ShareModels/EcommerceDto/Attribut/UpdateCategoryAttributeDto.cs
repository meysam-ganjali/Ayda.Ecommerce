using Ayda.Ecommerce.ShareModels.BaseModel;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Attribut;

public class UpdateCategoryAttributeDto :BaseDto<int> {
    public string Name { get; set; }
    public int CategoryId { get; set; }
}