namespace CompanyPost.Application.CQRS.Commands.Post;
public record UpdatePostCommand(UpdatePostDTO PostDTO) : IRequest<Unit>;