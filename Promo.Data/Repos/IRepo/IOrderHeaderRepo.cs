using Promo.Core.Models;

namespace Promo.Data.Repos.IRepo;
public interface IOrderHeaderRepo : IGenericRepo<OrderHeader>
{
    void Update(OrderHeader obj);
    void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
    void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
}
