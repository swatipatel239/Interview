using MvcTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminData()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminDataDisplay()
        {
            var BrekfastLeads = new List<tblBreakfast>();
            using (GujaratiCateringEntities8 dbContext = new GujaratiCateringEntities8())
            {
                BrekfastLeads = dbContext.tblBreakfasts.ToList();

            }
                return View(BrekfastLeads);
        }
        [HttpPost]
        public ActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {
                using (GujaratiCateringEntities8 dbContext = new GujaratiCateringEntities8())
                {
                    try
                    {
                        var v = dbContext.AdminLogins.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
                        if (v != null)
                        {
                            //return View();
                            Session["Admin"] = user.Username;
                            return RedirectToAction("AdminDataDisplay");
                            // return JavaScript(string.Format("document.location = '{0}';", "Admin/AdminData"));
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Username/Password or You are not an Admin";
                            return View(user);
                        }
                    }
                   
                    catch(Exception ex)
                    {
                        Response.Write("sd" + ex);
                        
                    }
                }
            }
            return View(user);
        }
    }
}