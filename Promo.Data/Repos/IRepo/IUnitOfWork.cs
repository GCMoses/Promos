namespace Promo.Data.Repos.IRepo;

public interface IUnitOfWork
{
    ICategoryRepo Category { get; }
    IPromoCoverRepo PromoCover { get; }
    IProductRepo Product { get; }
    IBusinessRepo Business { get; }
    IShoppingCartRepo ShoppingCart { get; }
    IAppUserRepo AppUser { get; }
    IOrderDetailRepo OrderDetail { get; }
    IOrderHeaderRepo OrderHeader { get; }


    void Save();
}