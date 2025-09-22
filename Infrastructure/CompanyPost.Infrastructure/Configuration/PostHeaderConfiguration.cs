namespace CompanyPost.Infrastructure.Configuration;
internal sealed class PostHeaderConfiguration : IEntityTypeConfiguration<PostHeader>
{
	public void Configure(EntityTypeBuilder<PostHeader> builder)
	{
		builder.HasKey(builder => builder.Id);

		builder.Property(builder => builder.Name)
			.HasMaxLength(100)
			.IsRequired();
	}
}
