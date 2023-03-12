using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.Ordering;

public class RequestPayDto:BaseDto<long>
{
    public Guid Guid { get; set; }
    public long UserId { get; set; }
    public  ApplicationUserDto User { get; set; }
    public int Amount { get; set; }
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public string Authority { get; set; }
    public long RefId { get; set; } = 0;
    public string Email { get; set; }
    public  List<OrderDto> Orders { get; set; }
}
public class CreateRequestPayDto{
    public Guid Guid { get; set; }
    public long UserId { get; set; }
    public int Amount { get; set; }
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public string Authority { get; set; }
    public long RefId { get; set; } = 0;
    public string Address { get; set; }
    public string PostalCode { get; set; }
}
public class UpdateRequestPayDto:BaseDto<long> {
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public string Authority { get; set; }
    public long RefId { get; set; } = 0;
}