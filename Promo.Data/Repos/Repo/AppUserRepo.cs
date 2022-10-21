using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Promo.Data.Repos.Repo;

public class AppUserRepo : GenericRepo<AppUser>, IAppUserRepo
{
    private AppDbContext _db;

    public AppUserRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }

}