namespace Ayda.Ecommerce.ShareModels.User;

public class AuthResultDto
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string? CellPhone { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
}