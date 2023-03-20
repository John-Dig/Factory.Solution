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
    public ActionResult Details(int id)
    {
      Engineer thisEngineer = _db.Engineers
          .Include(engineer => engineer.JoinEntities) //an Include() property can/ needs to be added for as many navigation properties as we have and need to fetch
          .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }
    public ActionResult AddTag(int id)
    {
      Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.TagId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddTag(Engineer engineer, int machineId)
    {
#nullable enable
      EnMa? joinEntity = _db.EnsMas.FirstOrDefault(join => (join.MachineId == machineId && join.EngineerId == engineer.EngineerId));
#nullable disable
      if (joinEntity == null && machineId != 0)
      {
        _db.EnsMas.Add(new EnMa() { MachineId = machineId, EngineerId = engineer.EngineerId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }
  }
}