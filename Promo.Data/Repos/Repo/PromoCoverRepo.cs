using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;


namespace Promo.Data.Repos.Repo;

public class PromoCoverRepo : GenericRepo<PromoCover>, IPromoCoverRepo
{
    private AppDbContext _db;

    public PromoCoverRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(PromoCover obj)
    {
        _db.PromoCovers.Update(obj);
    }
}