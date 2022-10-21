using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promo.Consumables;
using Promo.Core.Models;
using Promo.Data.Repos.IRepo;

namespace Promos.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = Statics.Role_Admin)]
public class BusinessController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BusinessController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        Business business = new();

        if (id == null || id == 0)
        {
            return View(business);
        }
        else
        {
            business = _unitOfWork.Business.GetFirstOrDefault(u => u.Id == id);
            return View(business);
        }
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Business obj, IFormFile? file)
    {

        if (ModelState.IsValid)
        {

            if (obj.Id == 0)
            {
                _unitOfWork.Business.Add(obj);
                TempData["success"] = "Business created";
            }
            else
            {
                _unitOfWork.Business.Update(obj);
                TempData["success"] = "Business updated";
            }
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
        return View(obj);
    }



    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var businessList = _unitOfWork.Business.GetAll();
        return Json(new { data = businessList });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Business.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        _unitOfWork.Business.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}
