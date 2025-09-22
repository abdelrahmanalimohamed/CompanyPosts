namespace CompanyPost.Application.CQRS.Handlers.Commands;
internal sealed class CreateCommandHandler : IRequestHandler<CreatePostCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;
	public CreateCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
	{
		var postHeader = _unitOfWork.Repository<PostHeader>();
		throw new NotImplementedException();
	}
}