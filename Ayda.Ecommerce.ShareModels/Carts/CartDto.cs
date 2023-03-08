using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.Carts;

public class CartDto:BaseDto<long>
{
    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }
    public int TotalSum { get; set; }
    public long UserId { get; set; }
    public  ApplicationUserDto ApplicationUser { get; set; }
    public  List<CartItemDto> CartItems { get; set; }
}

public class CreateCartDto
{
    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }
    public int TotalSum { get; set; }
    public long UserId { get; set; }
}
public class UpdateCartDto : BaseDto<long> {
    public Guid BrowserId { get; set; }
    public bool Finished { get; set; }
    public int TotalSum { get; set; }
    public long UserId { get; set; }
}
