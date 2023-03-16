namespace Ayda.Ecommerce.ShareModels.Finances.FeaturesInvoic;

public class CreateFeaturesInvoiceDto
{
    public Guid Guid { get; set; }
    public long UserId { get; set; }
    public int Amount { get; set; }
    public bool IsPay { get; set; }
    public DateTime? PayDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Authority { get; set; }
    public long RefId { get; set; }
    public string InvoicePhone { get; set; }
    public string PostalAddress { get; set; }
    public string PostalCode { get; set; }
}