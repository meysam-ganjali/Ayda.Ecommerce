using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.User;

namespace Ayda.Ecommerce.Domains.Finances;

public class Invoice : BaseEntity<long> {
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
    public long FeaturesInvoiceId { get; set; }
    [ForeignKey("FeaturesInvoiceId")]
    public virtual FeaturesInvoice FeaturesInvoice { get; set; }
    public OrderState OrderState { get; set; }
    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
}