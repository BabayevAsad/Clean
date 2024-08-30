using FluentValidation;

namespace Application.Products.Commands.Create;

public class CreateProductCommandValidator : ProductValidator<CreateProductCommand>
{
    public CreateProductCommandValidator() : base()
    {
        RuleFor(x => x.Brand).NotEmpty().WithMessage("Brand is required.");
        RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barcode is required.");
    }
}   