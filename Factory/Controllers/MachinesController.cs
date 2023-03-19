using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Machine> model = _db.Machines
                            .Include(machine => machine.Engineer)
                            .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
        return View(machine);
      }
      else
      {
        _db.Machines.Add(machine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Machine thisMachine = _db.Machines
                               .Include(mach => mach.Engineer)
                               .Include(machine => machine.JoinEntities)
                               //.ThenInclude(join => join.Tag)
                               .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Machines.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult AddTag(int id)
    // {
    //   Machine thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
    //   ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Title");
    //   return View(thisMachine);
    // }

    // [HttpPost]
    // public ActionResult AddTag(Machine machine, int tagId)
    // {
    //   #nullable enable
    //   MachineTag? joinEntity = _db.MachineTags.FirstOrDefault(join => (join.TagId == tagId && join.MachineId == machine.MachineId));
    //   #nullable disable
    //   if (joinEntity == null && tagId != 0)
    //   {
    //     _db.MachineTags.Add(new MachineTag() { TagId = tagId, MachineId = machine.MachineId });
    //     _db.SaveChanges();
    //   }
    //   return RedirectToAction("Details", new { id = machine.MachineId });
    // }   

    // [HttpPost]
    // public ActionResult DeleteJoin(int joinId)
    // {
    //   MachineTag joinEntry = _db.MachineTags.FirstOrDefault(entry => entry.MachineTagId == joinId);
    //   _db.MachineTags.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // } 
  }
}
