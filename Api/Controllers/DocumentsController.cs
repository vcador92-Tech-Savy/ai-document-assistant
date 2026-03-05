using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Documents.Models;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController(DocumentService service) : ControllerBase
{
    private readonly DocumentService _service = service;

    [HttpPost]
    public async Task<ActionResult<DocumentDto>> Create([FromBody] CreateDocumentRequest request, CancellationToken ct)
    {
        var dto = await _service.CreateAsync(request.FileName, ct);
        return Ok(dto);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DocumentDto>>> GetAll(CancellationToken ct)
        => Ok(await _service.GetAllAsync(ct));
}