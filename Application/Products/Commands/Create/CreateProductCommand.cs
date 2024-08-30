using MediatR;

namespace Application.Products.Commands.Create;

public class CreateProductCommand : ProductCommand, IRequest<int> 
{
    public string Brand { get; set; }
    public int Barcode { get; set; }
}