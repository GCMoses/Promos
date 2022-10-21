using Promo.Core.Models;

namespace Promo.Data.Repos.IRepo;
public interface IOrderDetailRepo : IGenericRepo<OrderDetail>
{
    void Update(OrderDetail obj);
}