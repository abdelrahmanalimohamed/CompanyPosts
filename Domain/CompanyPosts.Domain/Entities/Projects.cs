namespace CompanyPost.Domain.Entities;
public class Projects : BaseEntity , IHasName
{
	public string Name { get; set; } = string.Empty;
	public ICollection<Contracts> Contracts { get; set; } = new List<Contracts>();
	public ICollection<Posts> Posts { get; set; } = new List<Posts>();
}