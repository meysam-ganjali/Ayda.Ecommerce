namespace Ayda.Ecommerce.Domains.Base;

public class BaseEntity<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
}