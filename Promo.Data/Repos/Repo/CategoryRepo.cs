using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;


namespace Promo.Data.Repos.Repo;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
    private AppDbContext _db;

    public CategoryRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }
}