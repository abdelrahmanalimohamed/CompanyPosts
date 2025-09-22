namespace CompanyPost.Domain.Entities;
public class DeliveryMethods : BaseEntity , IHasName
{
	public ICollection<Posts> Posts { get; set; } = new List<Posts>();
	public string Name { get; set; } = string.Empty;
}