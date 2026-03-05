using Domain.Entities;

namespace Application.Abstractions.Persistence;

public interface IDocumentRepository
{
    Task<Document> AddAsync(Document document, CancellationToken ct = default);
    Task<IReadOnlyList<Document>> GetAllAsync(CancellationToken ct = default);
}