namespace CompanyPost.Application.DTO.Request;
public record UpdatePostDTO(
	Guid Id,
	string Subject,
	string DocumentNumber,
	string SerialNumber,
	DateTime DateOfPost,
	DateTime DateOfDelivery,
	Guid PostHeaderId,
	Guid PostTypeId,
	Guid PersonOrgId,
	Guid DeliveryMethodId,
	Guid DeliveryPersonId,
	Guid PostOriginalSenderId,
	Guid ProjectId,
	IFormFile? AttachmentUrl);