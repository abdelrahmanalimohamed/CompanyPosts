namespace CompanyPost.Application.DTO.Request;
public record CreateContractDTO(string value ,
	string details,
	string contract_num,
	DateTime contract_date,
	Guid person_org_id, 
	string working,	
	string? notes,
	Guid project_id,
	string currency,
	string purchase_order_ref , 
	IFormFile attachments);
