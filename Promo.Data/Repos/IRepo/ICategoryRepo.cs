using Promo.Core.Models;

namespace Promo.Data.Repos.IRepo;
public interface ICategoryRepo : IGenericRepo<Category>
{
    void Update(Category obj);
}
