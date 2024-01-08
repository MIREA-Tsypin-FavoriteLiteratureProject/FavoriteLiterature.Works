using FavoriteLiterature.Works.Application.Options;
using FavoriteLiterature.Works.Data.Entities;
using FavoriteLiterature.Works.Data.Repositories;
using FavoriteLiterature.Works.Domain.Attachments.Requests.Commands;
using FavoriteLiterature.Works.Domain.Attachments.Responses.Commands;
using MediatR;
using Microsoft.Extensions.Options;

namespace FavoriteLiterature.Works.Application.Handlers.Attachments.Commands;

public sealed class CreateAttachmentCommandHandler : IRequestHandler<CreateAttachmentCommand, CreateAttachmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AttachmentStorageOptions _attachmentStorageOptions;

    public CreateAttachmentCommandHandler(IUnitOfWork unitOfWork, IOptions<AttachmentStorageOptions> attachmentStorageOptions)
    {
        _unitOfWork = unitOfWork;
        _attachmentStorageOptions = attachmentStorageOptions.Value;
    }

    public async Task<CreateAttachmentResponse> Handle(CreateAttachmentCommand command, CancellationToken cancellationToken)
    {
        var workExists = await _unitOfWork.WorksRepository.ExistsAsync(x =>
                x.Id == command.WorkId,
            cancellationToken);
        if (!workExists)
        {
            throw new ArgumentException("Work is not exists!", nameof(command.WorkId));
        }

        var fileId = Guid.NewGuid();
        var attachmentType = Path.GetExtension(command.File.FileName);
        var fileName = string.Concat(fileId, attachmentType);
        var filePath = Path.Combine(_attachmentStorageOptions.RootDirectory, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await command.File.CopyToAsync(stream, cancellationToken);

        var attachment = new Attachment
        {
            WorkId = command.WorkId,
            FileId = fileId,
            AttachmentTypeId = attachmentType
        };

        try
        {
            await _unitOfWork.BeginTransactionAsync(new[]
            {
                () => _unitOfWork.AttachmentsRepository.Add(attachment)
            });
        }
        catch (Exception)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            throw;
        }

        return new CreateAttachmentResponse(attachment.Id);
    }
}