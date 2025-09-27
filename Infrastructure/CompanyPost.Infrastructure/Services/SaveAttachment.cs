namespace CompanyPost.Infrastructure.Services;
public class SaveAttachment : ISaveAttachment
{
	private readonly IWebHostEnvironment _environment;
	public SaveAttachment(IWebHostEnvironment environment)
	{
		_environment = environment;
	}
	public async Task<string> SaveAttachmentAsync(IFormFile attachment, string folderName, CancellationToken cancellationToken)
	{
		if (attachment == null || attachment.Length == 0)
			throw new Exception("Attachment is required and must not be empty.");

		var uploadsPath = Path.Combine(_environment.WebRootPath, folderName);
		if (!Directory.Exists(uploadsPath))
			Directory.CreateDirectory(uploadsPath);

		var fileName = Guid.NewGuid().ToString() + Path.GetExtension(attachment.FileName);
		var filePath = Path.Combine(uploadsPath, fileName);

		try
		{
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await attachment.CopyToAsync(stream, cancellationToken);
			}

			if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
				throw new Exception("File upload failed. Attachment was not saved properly.");

			return fileName;
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while uploading the attachment.", ex);
		}
	}
}