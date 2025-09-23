using Microsoft.AspNetCore.Http;

namespace CompanyPost.Application.DTO.Request;
public record CreatePostDTO(
	string subject , 
	string document_number , 
	string serial_number , 
	DateTime date_of_delivery,
	DateTime date_of_post,
	Guid post_original_sender_id, 
	Guid delivery_method_id, 
	Guid post_header_id , 
	Guid post_type_id ,
	Guid delivery_person_id,
	IFormFile attachment);