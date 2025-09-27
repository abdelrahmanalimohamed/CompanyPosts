namespace CompanyPost.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostHeaderController : ControllerBase
{
	private readonly IMediator _mediator;
	public PostHeaderController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpGet("get-post_headers")]
	public async Task<IActionResult> GetPostHeader()
	{
		var query = new GetPostHeaderQuery();
		var postTypes = await _mediator.Send(query);
		return Ok(postTypes);
	}
}