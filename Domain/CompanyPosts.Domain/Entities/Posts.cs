namespace CompanyPost.Domain.Entities;
public class Posts : BaseEntity
{
	public string Subject { get; set; } = string.Empty;
	public string Attachment { get; set; } = string.Empty;
	public string DocumentNumber { get; set; } = string.Empty;
	public string SerialNumber { get; set; } = string.Empty;
	public string working { get; set; } = string.Empty;
	public DateTime DateOfDelivery { get; set; }
	public DateTime DateOfPost { get; set; }
	public Guid PostOriginalSenderId { get; set; }
	public PersonOrg PostOriginalSenders { get; set; } = null!;
	public Guid DeliveryMethodId { get; set; }
	public DeliveryMethods DeliveryMethods { get; set; } = null!;
	public Guid DeliveryPersonId { get; set; }
	public PersonOrg DeliveryPersons { get; set; } = null!;
	public Guid CreatedById { get; set; }
	public SysUsers CreatedBy { get; set; } = null!;
	public Guid PostHeaderId { get; set; }
	public PostHeader PostHeaders { get; set; } = null!;
	public Guid PostTypeId { get; set; }
	public PostTypes PostTypes { get; set; } = null!;
	public Guid ProjectId { get; set; }
	public Projects Projects { get; set; } = null!;
}