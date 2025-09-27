namespace CompanyPost.Application.CQRS.Query;
public record GetPostTypesQuery(Guid postheaderId) 
	: IRequest<IEnumerable<PostTypesResponseDTO>>;