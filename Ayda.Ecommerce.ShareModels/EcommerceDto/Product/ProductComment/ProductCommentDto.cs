using Ayda.Ecommerce.ShareModels.BaseModel;
using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductComment;

public class ProductCommentDto:BaseDto<long>
{
    public string CommentText { get; set; }
    public int ProductId { get; set; }
    public  ProductDto Product { get; set; }
    public long UserId { get; set; }
    public  ApplicationUserDto ApplicationUser { get; set; }
}