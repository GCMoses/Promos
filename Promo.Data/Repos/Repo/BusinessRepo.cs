using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Promo.Data.Repos.Repo;

public class BusinessRepo : GenericRepo<Business>, IBusinessRepo
{
    private AppDbContext _db;

    public BusinessRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(Business obj)
    {
        _db.Businesses.Update(obj);
    }
}