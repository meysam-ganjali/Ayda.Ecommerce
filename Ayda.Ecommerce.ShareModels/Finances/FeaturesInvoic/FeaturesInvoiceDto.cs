using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.Finances.FeaturesInvoic;

public class FeaturesInvoiceDto:BaseDto<long>
{
    public Guid Guid { get; set; }
    public long UserId { get; set; }

    public  ApplicationUserDto User { get; set; }
    public int Amount { get; set; }
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public string Authority { get; set; } 
    public long RefId { get; set; }
    public string InvoicePhone { get; set; }
    public string PostalAddress { get; set; }
    public string PostalCode { get; set; }
    public  List<InvoicesDto> Invoices { get; set; }
}