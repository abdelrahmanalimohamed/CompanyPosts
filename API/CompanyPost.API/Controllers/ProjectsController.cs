namespace CompanyPost.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
	private readonly IMediator _mediator;
	public ProjectsController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpGet("get-projects")]
	public async Task<IActionResult> GetProjects(CancellationToken cancellationToken)
	{
		var query = new GetProjectsQuery();
		var projects = await _mediator.Send(query, cancellationToken);
		return Ok(projects);
	}
}