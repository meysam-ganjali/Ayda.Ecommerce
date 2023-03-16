using System.ComponentModel.DataAnnotations;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ayda.Ecommerce.Domains.Finances;

public class FeaturesInvoice : BaseEntity<long> {
    public Guid Guid { get; set; }
    public long UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
    public int Amount { get; set; }
    public bool IsPay { get; set; } = false;
    public DateTime? PayDate { get; set; }
    public string Authority { get; set; } = "Not Authority";
    public long RefId { get; set; } = -1;
    public string InvoicePhone { get; set; }
    public string PostalAddress { get; set; }
    [MinLength(10)]
    public string PostalCode { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
}