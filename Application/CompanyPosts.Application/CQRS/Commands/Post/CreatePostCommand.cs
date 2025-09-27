namespace CompanyPost.Application.CQRS.Commands.Post;
public class CreatePostCommand : IRequest<Unit>
{
	public CreatePostDTO CreatePostDTO { get; set; }
	public CreatePostCommand(CreatePostDTO createPostDTO)
	{
		CreatePostDTO = createPostDTO;
	}
}