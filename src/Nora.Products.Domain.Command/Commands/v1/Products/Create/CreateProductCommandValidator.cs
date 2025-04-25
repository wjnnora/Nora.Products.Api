using FluentValidation;

namespace Nora.Products.Domain.Command.Commands.v1.Products.Create;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(r => r.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(250);

        RuleFor(r => r.CategoryId)
            .GreaterThan(0);
    }
}