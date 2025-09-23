using Microsoft.AspNetCore.Hosting;

namespace CompanyPost.Application.CQRS.Handlers.Commands.Post;
internal sealed class CreatePostCommandHandler 
	: IRequestHandler<CreatePostCommand, Unit>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IWebHostEnvironment _environment;
	public CreatePostCommandHandler(
		IUnitOfWork unitOfWork , 
		IWebHostEnvironment webHostEnvironment)
	{
		_unitOfWork = unitOfWork;
		_environment = webHostEnvironment;
	}
	public async Task<Unit> Handle(
			CreatePostCommand request, 
		CancellationToken cancellationToken)
	{
		var postRepository = _unitOfWork.Repository<Posts>();
		string fileName = null;

		if (request.CreatePostDTO.attachment != null && request.CreatePostDTO.attachment.Length > 0)
		{
			// Ensure uploads folder exists
			var uploadsPath = Path.Combine(_environment.WebRootPath, "uploads");
			if (!Directory.Exists(uploadsPath))
				Directory.CreateDirectory(uploadsPath);

			// Generate unique filename
			fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.CreatePostDTO.attachment.FileName);

			// Save file
			var filePath = Path.Combine(uploadsPath, fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await request.CreatePostDTO.attachment.CopyToAsync(stream, cancellationToken);
			}
		}

		var entity = new Posts
		{
			Subject = request.CreatePostDTO.subject,
			Attachment = fileName,
			DocumentNumber = request.CreatePostDTO.document_number,
			SerialNumber = request.CreatePostDTO.serial_number,
			DateOfDelivery = request.CreatePostDTO.date_of_delivery,
			DateOfPost = request.CreatePostDTO.date_of_post,
			PostOriginalSenderId = request.CreatePostDTO.post_original_sender_id,
			DeliveryMethodId = request.CreatePostDTO.delivery_method_id,
			DeliveryPersonId = request.CreatePostDTO.delivery_person_id,
			CreatedById = Guid.Parse("26962e74-631d-41b9-adcb-141e93a54c56"),
			PostHeaderId = request.CreatePostDTO.post_header_id,
			PostTypeId = request.CreatePostDTO.post_type_id
		};

		await postRepository.AddAsync(entity, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);
		return Unit.Value;
	}
}