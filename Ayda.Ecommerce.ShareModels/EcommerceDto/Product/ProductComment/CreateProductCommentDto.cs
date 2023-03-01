namespace Ayda.Ecommerce.ShareModels.EcommerceDto.Product.ProductComment;

public class CreateProductCommentDto{
    public string CommentText { get; set; }
    public int ProductId { get; set; }
    public long UserId { get; set; }
    public bool IsShow { get; set; } = true;
}