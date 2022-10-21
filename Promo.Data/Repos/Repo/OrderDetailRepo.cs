using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Promo.Data.Repos.Repo;

public class OrderDetailRepo : GenericRepo<OrderDetail>, IOrderDetailRepo
{
    private AppDbContext _db;

    public OrderDetailRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(OrderDetail obj)
    {
        _db.OrderDetails.Update(obj);
    }
}
    