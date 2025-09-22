namespace CompanyPost.Infrastructure.Data;
public class CompanyPostDbContext : DbContext
{
	public CompanyPostDbContext(DbContextOptions<CompanyPostDbContext> options) 
		: base(options)
	{
	}
	public DbSet<PostHeader> PostHeaders { get; set; }
	public DbSet<PostTypes> PostTypes { get; set; }
	public DbSet<Posts> Posts { get; set; }
	public DbSet<DeliveryMethods> DeliveryMethods { get; set; }
	public DbSet<PersonOrg> PersonOrgs { get; set; }
	public DbSet<Contracts> Contracts { get; set; }
	public DbSet<Projects> Projects { get; set; }
	public DbSet<SysUsers> SysUsers { get; set; }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyPostDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}
}