namespace CompanyPost.Infrastructure.Seeds;
public static class SeedData
{
	public static async Task Initialize(CompanyPostDbContext context)
	{
		await SeedPostHeader(context);
		await SeedSysUser(context);
		await SeedPostTypes(context);
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

	private static async Task SeedPostTypes(CompanyPostDbContext context)
	{
		if (!context.PostTypes.Any())
		{
			var postIssued = await context.PostHeaders.Where(x => x.Name == "صادر")
					.Select(a => a.Id).FirstOrDefaultAsync();

			var postIncoming = await context.PostHeaders.Where(x => x.Name == "وارد")
					.Select(a => a.Id).FirstOrDefaultAsync();

			await context.PostTypes.AddRangeAsync(
					new PostTypes { PostId = postIssued ,  Type = "داخلي" },
					new PostTypes { PostId = postIssued, Type = "خارجي" },
					new PostTypes { PostId = postIssued, Type = "محول" },

					new PostTypes { PostId = postIncoming, Type = "داخلي" },
					new PostTypes { PostId = postIncoming, Type = "خارجي" }
				);
			await context.SaveChangesAsync();
		}
	}
}