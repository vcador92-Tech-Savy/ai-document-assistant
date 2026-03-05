using Infrastructure.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly AppDbContext _db;

    public DocumentsController(AppDbContext db) => _db = db;

    [HttpPost]
    public async Task<ActionResult<Document>> Create([FromBody] string fileName)
    {
        var doc = new Document { FileName = fileName };
        _db.Documents.Add(doc);
        await _db.SaveChangesAsync();
        return Ok(doc);
    }

    [HttpGet]
    public async Task<ActionResult<List<Document>>> GetAll()
        => Ok(await _db.Documents.AsNoTracking().ToListAsync());
}