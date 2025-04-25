using FluentValidation;

namespace Nora.Products.Domain.Command.Commands.v1.Categories.Create;

public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(r => r.Description)
            .NotNull()
            .NotEmpty()
            .MaximumLength(250);
    }
}