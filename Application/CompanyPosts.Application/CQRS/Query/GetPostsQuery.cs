namespace CompanyPost.Application.CQRS.Query;
public record GetPostsQuery : IRequest<IEnumerable<PostResponseDTO>>;