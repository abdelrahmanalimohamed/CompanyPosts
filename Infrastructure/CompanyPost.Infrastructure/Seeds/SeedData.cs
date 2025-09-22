namespace CompanyPost.Infrastructure.Seeds;
public static class SeedData
{
	public static async Task Initialize(CompanyPostDbContext context)
	{
		await SeedPostHeader(context);
		await SeedSysUser(context);
	}
	private static async Task SeedPostHeader(CompanyPostDbContext context)
	{
		if (!context.PostHeaders.Any())
		{
			await context.PostHeaders.AddRangeAsync(
				  new PostHeader { Name = "صادر" },
				  new PostHeader { Name = "وارد" }
			  );
			await context.SaveChangesAsync();
		}
	}
	private static async Task SeedSysUser(CompanyPostDbContext context)
	{
		if (!context.SysUsers.Any())
		{
			await context.SysUsers.AddRangeAsync(
				  new SysUsers
				  {
					  username = "admin",
					  password = BCrypt.Net.BCrypt.HashPassword("123456789"),
				  }
			  );
			await context.SaveChangesAsync();
		}
	}
}