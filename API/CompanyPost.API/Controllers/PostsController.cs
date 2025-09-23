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
	[HttpPost("create-post")]
	public async Task<IActionResult> CreatePost([FromForm] CreatePostDTO createPostDTO)
	{
		var command = new CreatePostCommand(createPostDTO);
		await _mediator.Send(command);
		return Ok();
	}

	[HttpGet("get-posts")]
	public async Task<IActionResult> GetPosts()
	{
		var query = new GetPostsQuery();
		var posts = await _mediator.Send(query);
		return Ok(posts);
	}
}