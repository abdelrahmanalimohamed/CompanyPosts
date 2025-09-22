namespace CompanyPost.Infrastructure.Configuration;
internal sealed class PostTypesConfiguration : IEntityTypeConfiguration<PostTypes>
{
	public void Configure(EntityTypeBuilder<PostTypes> builder)
	{
		builder.HasKey(builder => builder.Id);

		builder.Property(builder => builder.Type)
			.HasMaxLength(100)
			.IsRequired();

		builder.HasOne(builder => builder.PostHeader)
			.WithMany(t => t.PostTypes)
			.HasForeignKey(builder => builder.PostId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
