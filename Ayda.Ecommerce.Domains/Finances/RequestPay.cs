using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.User;

namespace Ayda.Ecommerce.Domains.Finances;

public class RequestPay : BaseEntity<long> {
    public Guid Guid { get; set; }

    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }

    

    public int Amount { get; set; }
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public string Authority { get; set; }
    public long RefId { get; set; } = 0;
    public virtual ICollection<Order> Orders { get; set; }
}