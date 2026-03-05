using Application.Documents.Models;
using FluentValidation;

namespace Application.Documents.Validation;

public class CreateDocumentRequestValidator : AbstractValidator<CreateDocumentRequest>
{
    public CreateDocumentRequestValidator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage("File name is required.")
            .MaximumLength(200)
            .WithMessage("FileName must be 200 characters or fewer.");
    }
}