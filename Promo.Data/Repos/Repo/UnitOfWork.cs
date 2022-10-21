using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;


namespace Promo.Data.Repos.Repo;

public class UnitOfWork : IUnitOfWork
{
    private AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
        Category = new CategoryRepo(_db);
        PromoCover = new PromoCoverRepo(_db);
        Product = new ProductRepo(_db);
        Business = new BusinessRepo(_db);
        AppUser = new AppUserRepo(_db);
        ShoppingCart = new ShoppingCartRepo(_db);
        OrderHeader = new OrderHeaderRepo(_db);
        OrderDetail = new OrderDetailRepo(_db);
    }
    public ICategoryRepo Category { get; private set; }
    public IPromoCoverRepo PromoCover { get; private set; }
    public IProductRepo Product { get; private set; }
    public IBusinessRepo Business { get; private set; }
    public IShoppingCartRepo ShoppingCart { get; private set; }

    public IAppUserRepo AppUser { get; private set; }
    public IOrderHeaderRepo OrderHeader { get; private set; }
    public IOrderDetailRepo OrderDetail { get; private set; }

    public void Save()
    {
        _db.SaveChanges();
    }
}
