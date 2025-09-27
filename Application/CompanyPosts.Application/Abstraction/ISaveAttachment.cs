namespace CompanyPost.Application.Abstraction;
public interface ISaveAttachment
{
	Task<string> SaveAttachmentAsync(IFormFile attachment, string folderName,CancellationToken cancellationToken);
}