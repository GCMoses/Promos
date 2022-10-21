using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;

namespace Promo.Data.Repos.Repo;

public class ShoppingCartRepo : GenericRepo<ShoppingCart>, IShoppingCartRepo
{
    private AppDbContext _db;

    public ShoppingCartRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public int DecrementCount(ShoppingCart shoppingCart, int count)
    {
        shoppingCart.Count -= count;
        return shoppingCart.Count;
    }
    public int IncrementCount(ShoppingCart shoppingCart, int count)
    {
        shoppingCart.Count += count;
        return shoppingCart.Count;
    }

}