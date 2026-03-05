using Application.Abstractions.Persistence;
using Domain.Entities;

namespace Application.Services;

public class DocumentService(IDocumentRepository repo)
{
    private readonly IDocumentRepository _repo = repo;

    public Task<Document> CreateAsync(string fileName, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("File is required", nameof(fileName));

        var doc = new Document { FileName = fileName };
        return _repo.AddAsync(doc, ct);
    }

    public Task<IReadOnlyList<Document>> GetAllAsync(CancellationToken ct = default)
        => _repo.GetAllAsync(ct);
}