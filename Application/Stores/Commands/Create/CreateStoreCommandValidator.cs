using FluentValidation;

namespace Application.Stores.Commands.Create;

public class CreateStoreCommandValidator : StoreValidator<CreateStoreCommand>
{
    public CreateStoreCommandValidator() : base()
    {
      
    }
}   