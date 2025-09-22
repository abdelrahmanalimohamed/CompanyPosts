namespace CompanyPost.Domain.Entities;
public class PostHeader : BaseEntity , IHasName
{
	public string Name { get; set; } = string.Empty;
	public ICollection<PostTypes> PostTypes { get; set; } = new List<PostTypes>();
}