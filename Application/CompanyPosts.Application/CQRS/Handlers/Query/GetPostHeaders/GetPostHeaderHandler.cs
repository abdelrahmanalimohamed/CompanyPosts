namespace CompanyPost.Application.CQRS.Handlers.Query.GetPostHeaders;
internal sealed class GetPostHeaderHandler
	: IRequestHandler<GetPostHeaderQuery, IEnumerable<PostHeaderResponseDTO>>
{
	private readonly IUnitOfWork _unitOfWork;
	public GetPostHeaderHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<IEnumerable<PostHeaderResponseDTO>> Handle(GetPostHeaderQuery request, CancellationToken cancellationToken)
	{
		var postHeaderRepository = _unitOfWork.Repository<PostHeader>();

		var postHeaders = await postHeaderRepository.ListAllAsync(cancellationToken);

		var postHeaderDTOs = postHeaders.Select(ph => new PostHeaderResponseDTO(
			ph.Name,
			ph.Id
		));
		return postHeaderDTOs;
	}
}
