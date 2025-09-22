namespace CompanyPost.Infrastructure.Configuration;
internal sealed class ContractConfiguration : IEntityTypeConfiguration<Contracts>
{
	public void Configure(EntityTypeBuilder<Contracts> builder)
	{
		builder.HasKey(builder => builder.Id);

		builder.Property(builder => builder.Details)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.Notes)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.Attachments)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.ContractNumber)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.Value)
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(builder => builder.DateOfDelivery)
			.IsRequired();

		builder.Property(builder => builder.Contract_Date)
			.IsRequired();

		builder.HasOne(builder => builder.PersonOrgFrom)
			.WithMany(t => t.ContractsPersonOrgFrom)
			.HasForeignKey(builder => builder.PersonOrgFromId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(builder => builder.PersonOrgPreparedBy)
			.WithMany(t => t.ContractsPersonOrgPreparedBy)
			.HasForeignKey(builder => builder.PersonOrgPreparedById)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(builder => builder.Projects)
			.WithMany(t => t.Contracts)
			.HasForeignKey(builder => builder.ProjectId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(builder => builder.Status)
			.HasConversion<int>()
			.IsRequired();

		builder.Property(builder => builder.Currency)
			.HasConversion<int>()
			.IsRequired();
	}
}