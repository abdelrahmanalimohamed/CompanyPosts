namespace CompanyPost.Domain.Entities;
public class PostTypes : BaseEntity
{
	public string Type { get; set; } = string.Empty;
	public Guid PostId { get; set; }
	public PostHeader PostHeader { get; set; } = null!;
	public ICollection<Posts> Posts { get; set; } = new List<Posts>();
}