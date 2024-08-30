using FluentValidation;

namespace Application.Products.Commands
{
    public abstract class ProductValidator<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}