using FluentValidation;

namespace Application.Stores.Commands
{
    public abstract class StoreValidator<T> : AbstractValidator<T> where T : StoreCommand
    {
        protected StoreValidator()
        { 
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(100).
                WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.Location).NotEmpty().WithMessage("Location is required.");
            RuleFor(x => x.Count).NotEmpty().WithMessage("Count is required.");
        }
    }
}