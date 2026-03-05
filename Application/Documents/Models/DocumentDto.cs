namespace Application.Documents.Models;

public sealed record DocumentDto(Guid Id, string FileName, DateTime UploadedAtUtc);