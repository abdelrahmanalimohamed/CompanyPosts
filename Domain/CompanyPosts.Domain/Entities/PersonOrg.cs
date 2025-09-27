namespace CompanyPost.Domain.Entities;
public class PersonOrg : BaseEntity , IHasName
{
	public string SAP_BP { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string? Address { get; set; }
	public string? Phone { get; set; }
	public string? Email { get; set; }
	public string? Contact_Person { get; set; }
	public ICollection<Posts> PostsAsOriginalSender { get; set; } = new List<Posts>();
	public ICollection<Posts> PostsAsDeliveryPerson { get; set; } = new List<Posts>();
	public ICollection<Contracts> Contracts { get; set; } = new List<Contracts>();
}