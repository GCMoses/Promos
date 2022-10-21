using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Promo.Consumables;
using Promo.Core.Models;
using Promo.Data.Repos.IRepo;

namespace Promos.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = Statics.Role_Admin)]
public class PromoCoverController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public PromoCoverController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        IEnumerable<PromoCover> objCoverTypeList = _unitOfWork.PromoCover.GetAll();
        return View(objCoverTypeList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PromoCover obj)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.PromoCover.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Promo Cover created";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.PromoCover.GetFirstOrDefault(u => u.Id == id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(PromoCover obj)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.PromoCover.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Promo Cover updated";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var CoverTypeFromDbFirst = _unitOfWork.PromoCover.GetFirstOrDefault(u => u.Id == id);

        if (CoverTypeFromDbFirst == null)
        {
            return NotFound();
        }

        return View(CoverTypeFromDbFirst);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _unitOfWork.PromoCover.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }

        _unitOfWork.PromoCover.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Promo Cover deleted";
        return RedirectToAction("Index");

    }
}
