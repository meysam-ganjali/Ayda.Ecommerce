namespace Ayda.Ecommerce.ShareModels.Finances;

public class CreateInvoicDto
{
    public long UserId { get; set; }
    public long FeaturesInvoiceId { get; set; }
    public OrderStateDto OrderState { get; set; }
}