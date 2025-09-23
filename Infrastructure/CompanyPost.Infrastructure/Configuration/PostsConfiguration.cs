namespace CompanyPost.Infrastructure.Configuration;
internal sealed class PostsConfiguration : IEntityTypeConfiguration<Posts>
{
	public void Configure(EntityTypeBuilder<Posts> builder)
	{
		builder.HasKey(builder => builder.Id);

		builder.Property(builder => builder.Subject)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.SerialNumber)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.DocumentNumber)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.Attachment)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.DateOfDelivery)
			.IsRequired();

		builder.HasOne(builder => builder.PostOriginalSenders)
			.WithMany(t => t.PostsAsOriginalSender)
			.HasForeignKey(builder => builder.PostOriginalSenderId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(builder => builder.DeliveryPersons)
			.WithMany(t => t.PostsAsDeliveryPerson)
			.HasForeignKey(builder => builder.DeliveryPersonId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(builder => builder.DeliveryMethods)
			.WithMany(t => t.Posts)
			.HasForeignKey(builder => builder.DeliveryMethodId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(builder => builder.CreatedBy)
			.WithMany(t => t.Posts)
			.HasForeignKey(builder => builder.CreatedById)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(builder => builder.PostHeaders)
			.WithMany(t => t.Posts)
			.HasForeignKey(builder => builder.PostHeaderId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(builder => builder.PostTypes)
			.WithMany(t => t.Posts)
			.HasForeignKey(builder => builder.PostTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(builder => builder.DocumentNumber)
			.IsUnique();
	}
}