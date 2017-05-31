using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diplom_1._1.ViewModels;
using Diplom_1._1.Models;
using Diplom.Models;

namespace Diplom_1._1.Controllers
{
    public class AddRoomController : Controller
    {
        MyContext db = new MyContext();

        // GET: AddRoom
        [HttpGet]
        public ActionResult Index()
        {
            AddRoomViewModel model = new AddRoomViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AddRoomViewModel model)
        {
            db.Groups.Add(new Group { Name = model.NewGroup });
            db.SaveChanges();
            model.Added = true;
            return View(model);
        }
    }
}