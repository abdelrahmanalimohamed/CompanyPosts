﻿namespace CompanyPost.Application.CQRS.Handlers.Query.GetPersonOrgs;
internal class GetPersonOrgsHandler
	: IRequestHandler<GetPersonOrgQuery, IEnumerable<PersonOrgResponseDTO>>
{
	private readonly IUnitOfWork _unitOfWork;
	public GetPersonOrgsHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<IEnumerable<PersonOrgResponseDTO>> Handle(
		GetPersonOrgQuery request, 
		CancellationToken cancellationToken)
	{
		var personOrgRepository = _unitOfWork.Repository<PersonOrg>();

		var personOrgs = await personOrgRepository.ListAllAsync(cancellationToken);

		var personOrgDTOs = personOrgs.Select(po => new PersonOrgResponseDTO(
			po.Name,
			po.Id
		));
		
		return personOrgDTOs;
	}
}