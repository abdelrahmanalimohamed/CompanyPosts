namespace CompanyPost.Domain.Entities;
public class PersonOrg : BaseEntity , IHasName
{
	public string SAP_BP { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Address { get; set; } = string.Empty;
	public string Phone { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Contact_Person { get; set; } = string.Empty;
	public ICollection<Posts> PostsAsOriginalSender { get; set; } = new List<Posts>();
	public ICollection<Posts> PostsAsDeliveryPerson { get; set; } = new List<Posts>();
	public ICollection<Contracts> ContractsPersonOrgFrom { get; set; } = new List<Contracts>();
	public ICollection<Contracts> ContractsPersonOrgPreparedBy { get; set; } = new List<Contracts>();
}