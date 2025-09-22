namespace CompanyPost.API;
public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddAuthorization();
		builder.Services.AddControllers();
		builder.Services
			  .AddApplication()
			  .AddInfrastructure(builder.Configuration);

		var app = builder.Build();


		using (var scope = app.Services.CreateScope())
		{
			var context = scope.ServiceProvider.GetRequiredService<CompanyPostDbContext>();
			context.Database.Migrate();
			await SeedData.Initialize(context);
		}

		// Configure the HTTP request pipeline.

		app.UseHttpsRedirection();

		app.UseAuthentication();
		app.UseAuthorization();
		app.MapControllers();

		app.Run();
	}
}