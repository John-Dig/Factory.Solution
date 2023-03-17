using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
      private readonly ToDoListContext _db;

      public HomeController(ToDoListContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        Engineer[] cats = _db.Engineers.ToArray();
        Machine[] machines = _db.Machines.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("engineers", cats);
        model.Add("machines", machines);
        return View(model);
      }
    }
}