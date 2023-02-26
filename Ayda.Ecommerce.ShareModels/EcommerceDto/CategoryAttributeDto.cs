using Ayda.Ecommerce.ShareModels.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto;

public class CategoryAttributeDto:BaseDto<int>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public  CategoryDto Category { get; set; }
}