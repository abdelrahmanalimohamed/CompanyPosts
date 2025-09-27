namespace CompanyPost.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostTypesController : ControllerBase
{
	private readonly IMediator _mediator;
	public PostTypesController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpGet("get-post-types/{postheaderId}")]
	public async Task<IActionResult> GetPostTypes(Guid postheaderId)
	{
		var query = new GetPostTypesQuery(postheaderId);
		var postTypes = await _mediator.Send(query);
		return Ok(postTypes);
	}
}