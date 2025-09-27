namespace CompanyPost.Application.CQRS.Query;
public record GetProjectsQuery : IRequest<IEnumerable<ProjectsResponseDTO>>;