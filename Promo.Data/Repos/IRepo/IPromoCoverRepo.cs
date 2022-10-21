using Promo.Core.Models;

namespace Promo.Data.Repos.IRepo;
public interface IPromoCoverRepo : IGenericRepo<PromoCover>
{
    void Update(PromoCover obj);
}
