using Promo.Core.Models;
using Promo.Data.AppData;
using Promo.Data.Repos.IRepo;

namespace Promo.Data.Repos.Repo;

public class ProductRepo : GenericRepo<Product>, IProductRepo
{
    private AppDbContext _db;

    public ProductRepo(AppDbContext db) : base(db)
    {
        _db = db;
    }


    public void Update(Product obj)
    {
        var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
        if (objFromDb != null)
        {
            objFromDb.Name = obj.Name;
            objFromDb.SocialLink = obj.SocialLink;
            objFromDb.Description = obj.Description;
            objFromDb.ContactDetails = obj.ContactDetails;
            objFromDb.WhatsApp = obj.WhatsApp;
            objFromDb.Facebook = obj.Facebook;
            objFromDb.Instagram = obj.Instagram;
            objFromDb.Price = obj.Price;
            objFromDb.Price50 = obj.Price50;
            objFromDb.ListPrice = obj.ListPrice;
            objFromDb.Price100 = obj.Price100;
            objFromDb.CategoryId = obj.CategoryId;
            objFromDb.PromoCoverId = obj.PromoCoverId;
            if (obj.ImageUrl != null)
            {
                objFromDb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}

