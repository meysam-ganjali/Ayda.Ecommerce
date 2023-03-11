using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.User;

namespace Ayda.Ecommerce.Domains.Finances;

public class Order : BaseEntity<long>
{
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }


    public long RequestPayId { get; set; }
    [ForeignKey("RequestPayId")]
    public virtual RequestPay RequestPay { get; set; }

    public OrderState OrderState { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}