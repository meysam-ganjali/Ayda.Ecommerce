using System.ComponentModel.DataAnnotations.Schema;
using Ayda.Ecommerce.ShareModels.EcommerceDto.Product;

namespace Ayda.Ecommerce.ShareModels.Finances.InvoiceItems;

public class InvoiceItemDto
{
    public long InvoiceId { get; set; }
    public  InvoicesDto Invoice { get; set; }
    public int ProductId { get; set; }
    public  ProductDto Product { get; set; }
    public int Price { get; set; }
    public int Count { get; set; }
}