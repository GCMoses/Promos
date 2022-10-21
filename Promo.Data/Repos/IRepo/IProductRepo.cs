using Promo.Core.Models;

namespace Promo.Data.Repos.IRepo;

public interface IProductRepo : IGenericRepo<Product>
{
    void Update(Product obj);

}
