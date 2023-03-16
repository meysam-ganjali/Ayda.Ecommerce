using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.Domains.Base;
using Ayda.Ecommerce.Domains.Ecommerce;

namespace Ayda.Ecommerce.Domains.Finances;

public class InvoiceItem : BaseEntity<long> {
    public long InvoiceId { get; set; }
    [ForeignKey("InvoiceId")]
    public virtual Invoice Invoice { get; set; }
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
}