using FluentValidation;

namespace Application.Books.Commands.Create;

public class CreateBookCommandValidator : BookValidator<CreateBookCommand> //niye internal class etdik
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.");
        RuleFor(x => x.PageCount).NotEmpty().WithMessage("PageCount is required.");

    }
}