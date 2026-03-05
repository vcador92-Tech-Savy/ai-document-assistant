using Application.Abstractions.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class DocumentRepository(AppDbContext db) : IDocumentRepository
{
    private readonly AppDbContext _db = db;

    public async Task<Document> AddAsync(Document document, CancellationToken ct = default)
    {
        _db.Documents.Add(document);
        await _db.SaveChangesAsync(ct);
        return document;
    }

    public async Task<IReadOnlyList<Document>> GetAllAsync(CancellationToken ct = default)
        => await _db.Documents.AsNoTracking().OrderByDescending(d => d.UploadedAtUtc).ToListAsync(ct);
}