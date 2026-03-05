namespace Domain.Entities;

public class Document
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FileName { get; set; } = default!;
    public DateTime UploadedAtUtc { get; set; } = DateTime.UtcNow;
}