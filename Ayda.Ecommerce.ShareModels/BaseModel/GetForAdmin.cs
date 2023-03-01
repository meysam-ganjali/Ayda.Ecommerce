using Ayda.Ecommerce.ShareModels.User;

namespace Ayda.Ecommerce.ShareModels.BaseModel;

public class GetForAdmin<TData> {
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public List<TData> EntityDto { get; set; }
}