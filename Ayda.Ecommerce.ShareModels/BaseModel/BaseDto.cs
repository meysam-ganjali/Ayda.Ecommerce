namespace Ayda.Ecommerce.ShareModels.BaseModel;

public class BaseDto<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
}