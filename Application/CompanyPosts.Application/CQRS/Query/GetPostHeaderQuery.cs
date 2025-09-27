namespace CompanyPost.Application.CQRS.Query;
public record GetPostHeaderQuery : IRequest<IEnumerable<PostHeaderResponseDTO>>;