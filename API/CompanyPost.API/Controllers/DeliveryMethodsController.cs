namespace CompanyPost.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeliveryMethodsController : ControllerBase
{
	private readonly IMediator _mediator;
	public DeliveryMethodsController(IMediator mediator)
	{
		_mediator = mediator;
	}
	[HttpGet("get-delivery-methods")]
	public async Task<IActionResult> GetDeliveryMethods()
	{
		var query = new GetDeliveryMethodsQuery();
		var deliveryMethods = await _mediator.Send(query);
		return Ok(deliveryMethods);
	}
}