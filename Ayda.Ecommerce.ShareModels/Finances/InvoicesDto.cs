using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Finances.FeaturesInvoic;
using Ayda.Ecommerce.ShareModels.Finances.InvoiceItems;
using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.Finances;

public class InvoicesDto:BaseDto<long>
{
    public long UserId { get; set; }
    public  ApplicationUserDto User { get; set; }
    public long FeaturesInvoiceId { get; set; }
    public  FeaturesInvoiceDto FeaturesInvoice { get; set; }
    public OrderStateDto OrderState { get; set; }
    public  List<InvoiceItemDto> InvoiceItems { get; set; }
}