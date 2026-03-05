using Infrastructure.Persistence;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController(DocumentService service) : ControllerBase
{
    private readonly DocumentService _service = service;

    [HttpPost]
    public async Task<ActionResult<Document>> Create([FromBody] string fileName, CancellationToken ct)
    {
        var doc = await _service.CreateAsync(fileName, ct);
        return Ok(doc);
    }

    [HttpGet]
    public async Task<ActionResult<List<Document>>> GetAll(CancellationToken ct)
        => Ok(await _service.GetAllAsync(ct));
}