namespace CompanyPosts.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
	private readonly IMediator _mediator;
	public PostsController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpPost]
	public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO createPostDTO)
	{
		var command = new CreatePostCommand(createPostDTO);
		await _mediator.Send(command);
		return Ok();
	}
}