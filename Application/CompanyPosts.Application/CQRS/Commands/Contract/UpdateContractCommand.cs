namespace CompanyPost.Application.CQRS.Commands.Contract;
public record UpdateContractCommand(UpdateContractDTO UpdateContractDTO) : IRequest<Unit>;