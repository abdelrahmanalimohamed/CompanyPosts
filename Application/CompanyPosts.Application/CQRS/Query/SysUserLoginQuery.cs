namespace CompanyPost.Application.CQRS.Query;
public record SysUserLoginQuery(string usernameOrEmail , string password) 
	: IRequest<AuthResultDTO>;