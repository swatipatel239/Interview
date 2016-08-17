using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        AddData InsertDb = new AddData();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        public ActionResult InsertData()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayData()
        {
            var BrekfastLeads = new List<AddData>();
            using (IterviewDbEntities dbContext = new IterviewDbEntities())
            {
                BrekfastLeads = dbContext.AddDatas.ToList();

            }
            return View(BrekfastLeads);
        }
        [HttpPost]
        public ActionResult InsertData(AddData model)
        {
            if (ModelState.IsValid)
            {
                using (IterviewDbEntities DbContext = new IterviewDbEntities())
                {
                    try
                    {
                        InsertDb.Name = model.Name;
                        InsertDb.Number = model.Number;
                        InsertDb.Email = model.Email;
                        InsertDb.Message = model.Message;
                        DbContext.AddDatas.Add(InsertDb);
                        DbContext.SaveChanges();
                        return RedirectToAction("DisplayData");
                    }
                    catch
                    {
                    }
                }

            }
            return View(model);
        }
    }
}