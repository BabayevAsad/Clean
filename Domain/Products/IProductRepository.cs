using System.Threading.Tasks;
using Domain.Base;

namespace Domain.Products;

public interface IProductRepository : IBaseRepository<Product>
{
    Product GetByName(string name);
   
}