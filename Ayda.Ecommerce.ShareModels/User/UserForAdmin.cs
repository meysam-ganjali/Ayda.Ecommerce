namespace Ayda.Ecommerce.ShareModels.User;

public class UserForAdmin
{
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public List<ApplicationUserDto> UserDtos { get; set; }
}