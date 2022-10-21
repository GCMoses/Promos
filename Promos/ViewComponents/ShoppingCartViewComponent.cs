using Microsoft.AspNetCore.Mvc;
using Promo.Consumables;
using Promo.Data.Repos.IRepo;
using System.Security.Claims;

namespace Promos.ViewComponents;

public class ShoppingCartViewComponent : ViewComponent
{
    private readonly IUnitOfWork _unitOfWork;
    public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null)
        {
            if (HttpContext.Session.GetInt32(Statics.SessionCart) != null)
            {
                return View(HttpContext.Session.GetInt32(Statics.SessionCart));
            }
            else
            {
                HttpContext.Session.SetInt32(Statics.SessionCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.AppUserId == claim.Value).ToList().Count);
                return View(HttpContext.Session.GetInt32(Statics.SessionCart));
            }
        }
        else
        {
            HttpContext.Session.Clear();
            return View(0);
        }
    }
}
