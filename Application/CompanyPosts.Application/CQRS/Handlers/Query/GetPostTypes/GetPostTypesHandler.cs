namespace CompanyPost.Application.CQRS.Handlers.Query.GetPostTypes;
internal sealed class GetPostTypesHandler
	: IRequestHandler<GetPostTypesQuery, IEnumerable<PostTypesResponseDTO>>
{
	private readonly IUnitOfWork _unitOfWork;
	public GetPostTypesHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<IEnumerable<PostTypesResponseDTO>> Handle(GetPostTypesQuery request, CancellationToken cancellationToken)
	{
		var postTypeRepository = _unitOfWork.Repository<PostTypes>();
		var postTypes = await postTypeRepository.FindAllAsync(x => x.PostId == request.postheaderId);
		var postTypeDTOs = postTypes.Select(pt => new PostTypesResponseDTO(
			pt.Type,
			pt.Id
		));
		return postTypeDTOs;
	}
}
