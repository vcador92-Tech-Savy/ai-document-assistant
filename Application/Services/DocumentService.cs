using Application.Abstractions.Persistence;
using Application.Documents.Models;
using Domain.Entities;

namespace Application.Services;

public class DocumentService(IDocumentRepository repo)
{
    private readonly IDocumentRepository _repo = repo;

    public async Task<DocumentDto> CreateAsync(string fileName, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("File is required", nameof(fileName));

        var doc = new Document { FileName = fileName.Trim() };
        var saved = await _repo.AddAsync(doc, ct);

        return new DocumentDto(saved.Id, saved.FileName, saved.UploadedAtUtc);
    }

    public async Task<IReadOnlyList<DocumentDto>> GetAllAsync(CancellationToken ct = default)
        => (await _repo.GetAllAsync(ct)).Select(d => new DocumentDto(d.Id, d.FileName, d.UploadedAtUtc)).ToList();
}