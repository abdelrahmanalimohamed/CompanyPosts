namespace CompanyPost.Application.CQRS.Handlers.Query.GetDeliveryMethods;
internal sealed class GetDeliveryMethodsHandler
	: IRequestHandler<GetDeliveryMethodsQuery, IEnumerable<DeliveryMethodsResponseDTO>>
{
	private readonly IUnitOfWork _unitOfWork;
	public GetDeliveryMethodsHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<IEnumerable<DeliveryMethodsResponseDTO>> Handle(GetDeliveryMethodsQuery request, CancellationToken cancellationToken)
	{
		var deliveryMethodRepository = _unitOfWork.Repository<DeliveryMethods>();
		var deliveryMethods = await deliveryMethodRepository.ListAllAsync(cancellationToken);
		var deliveryMethodDTOs = deliveryMethods.Select(dm => new DeliveryMethodsResponseDTO(
			dm.Name,
			dm.Id
		));
		return deliveryMethodDTOs;
	}
}
