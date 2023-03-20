using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineers.ToList());
      // List<Engineer> model = _db.Engineers
      //                       .Include(engineer => engineer.Name)
      //                       .ToList();
      // return View(model);
    }

    // public ActionResult Create()
    // {
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View();
    // }

    // [HttpPost]
    // public ActionResult Create(Engineer engineer)
    // {
    //   if (engineer.CategoryId == 0)
    //   {
    //     return RedirectToAction("Create");
    //   }
    //   _db.Engineers.Add(engineer);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }



    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
          .Include(engineer => engineer.JoinEntities) //an Include() property can/ needs to be added for as many navigation properties as we have and need to fetch
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }
    // public ActionResult Details(int id)
    // {
    //   Engineer thisEngineer = _db.Engineers
    //                       .Include(engineer => engineer.Category)
    //                       .FirstOrDefault(engineer => engineer.EngineerId == id);
    //   return View(thisEngineer);
    // }

    // public ActionResult Edit(int id)
    // {
    //   Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisEngineer);
    // }

    // [HttpPost]
    // public ActionResult Edit(Engineer engineer)
    // {
    //   _db.Engineers.Update(engineer);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
    //   return View(thisEngineer);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
    //   _db.Engineers.Remove(thisEngineer);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}