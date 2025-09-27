namespace CompanyPost.Application.CQRS.Commands;
public record CreateContractCommand(CreateContractDTO CreatrContractDTO) : IRequest<Unit>;
