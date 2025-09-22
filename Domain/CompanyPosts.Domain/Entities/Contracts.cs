namespace CompanyPost.Domain.Entities;
public class Contracts : BaseEntity
{
	public string Value { get; set; } = string.Empty;
	public string Details { get; set; } = string.Empty;
	public string ContractNumber { get; set; } = string.Empty;
	public string Notes { get; set; } = string.Empty;
	public string Attachments { get; set; } = string.Empty;	
	public DateTime Contract_Date { get; set; }
	public DateTime DateOfDelivery { get; set; }
	public Guid PersonOrgFromId { get; set; }
	public PersonOrg PersonOrgFrom { get; set; } = null!;
	public Guid PersonOrgPreparedById { get; set; }
	public PersonOrg PersonOrgPreparedBy { get; set; } = null!;
	public Guid ProjectId { get; set; }
	public Projects Projects { get; set; } = null!;
	public ContractStatus Status { get; set; }
	public Currency Currency { get; set; }
}