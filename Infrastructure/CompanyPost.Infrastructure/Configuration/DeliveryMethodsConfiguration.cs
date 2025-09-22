namespace CompanyPost.Infrastructure.Configuration;
internal sealed class DeliveryMethodsConfiguration : IEntityTypeConfiguration<DeliveryMethods>
{
	public void Configure(EntityTypeBuilder<DeliveryMethods> builder)
	{
		builder.HasKey(builder => builder.Id);

		builder.Property(builder => builder.Name)
			.HasMaxLength(50)
			.IsRequired();
	}
}