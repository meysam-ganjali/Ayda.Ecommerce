namespace Ayda.Ecommerce.ShareModels.Finances;

public class CreateInvoicDto
{
    public long UserId { get; set; }
    public long FeaturesInvoiceId { get; set; }
    public OrderStateDto OrderState { get; set; }
    public long CartId { get; set; }
    public string Authority { get; set; }
    public int RefId { get; set; }
}