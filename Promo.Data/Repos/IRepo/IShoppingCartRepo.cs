using Promo.Core.Models;

namespace Promo.Data.Repos.IRepo;
public interface IShoppingCartRepo : IGenericRepo<ShoppingCart>
{
    int IncrementCount(ShoppingCart shoppingCart, int count);
    int DecrementCount(ShoppingCart shoppingCart, int count);
}
