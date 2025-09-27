namespace CompanyPost.Application.CQRS.Query;
public record GetContractsQuery : IRequest<IEnumerable<ContractResponeDTO>>;