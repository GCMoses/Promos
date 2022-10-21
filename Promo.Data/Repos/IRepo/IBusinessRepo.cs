using Promo.Core.Models;

namespace Promo.Data.Repos.IRepo;
public interface IBusinessRepo : IGenericRepo<Business>
{
    void Update(Business obj);
}
