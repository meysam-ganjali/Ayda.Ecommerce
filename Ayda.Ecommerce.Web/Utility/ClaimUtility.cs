using System.Security.Claims;

namespace Ayda.Ecommerce.Web.Utility;

public static class ClaimUtility
{
	public static long? GetUserId(ClaimsPrincipal User)
	{
		try
		{
			var claimsIdentity = User.Identity as ClaimsIdentity;
			long userId = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
			return userId;
		}
		catch (Exception)
		{

			return null;
		}

	}

	public static string? UserInRole(ClaimsPrincipal User)
	{
		try
		{
			var claimsIdentity = User.Identity as ClaimsIdentity;
			string roleName = claimsIdentity.FindFirst(ClaimTypes.Role).Value;
			return roleName;
		}
		catch (Exception)
		{

			return null;
		}

	}

	public static string? UserName(ClaimsPrincipal User)
	{
		try
		{
			var claimsIdentity = User.Identity as ClaimsIdentity;
			string fullName = claimsIdentity.FindFirst(ClaimTypes.Name).Value;
			return fullName;
		}
		catch (Exception)
		{

			return null;
		}
	}
}