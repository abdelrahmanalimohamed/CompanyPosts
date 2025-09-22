namespace CompanyPost.Application.CQRS.Handlers.Query;
internal class SysUserLoginHandler : IRequestHandler<SysUserLoginQuery, AuthResultDTO>
{
	private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
	private readonly IJWTGenerator _jwtGenerator;
	public SysUserLoginHandler(
		IUnitOfWork unitOfWork,
		IPasswordService passwordService,
		IJWTGenerator jWTGenerator)
	{
		_unitOfWork = unitOfWork;
		_passwordService = passwordService;
		_jwtGenerator = jWTGenerator;
	}
	public async Task<AuthResultDTO> Handle(SysUserLoginQuery request, CancellationToken cancellationToken)
	{
		var userRepo = _unitOfWork.Repository<SysUsers>();

		var user = await userRepo.FindAsync(
			u => u.username == request.usernameOrEmail.ToLowerInvariant() || 
			u.email == request.usernameOrEmail.ToLowerInvariant());

		if (user is null || !_passwordService.VerifyPassword(request.password, user.password))
		{
			return new AuthResultDTO(false, "Invalid password or email");
		}

		var token = _jwtGenerator.CreateToken(user.Id);
		return new AuthResultDTO(true , "Success" , token);
	}
}