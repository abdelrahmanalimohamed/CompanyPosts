namespace CompanyPost.Application.CQRS.Query;
public record GetDeliveryMethodsQuery : IRequest<IEnumerable<DeliveryMethodsResponseDTO>>;