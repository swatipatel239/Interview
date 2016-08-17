using MvcTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcTest2.Controllers
{
    public class HomeController : Controller
    {
        GujaratiCateringEntities8 dbcontext = new GujaratiCateringEntities8();
        Lead lead = new Lead();
        tblBreakfast breakfast = new tblBreakfast();
       
        public object Accessor { get; private set; }

        public ActionResult Index()
        {
           // ViewBag.URL = Url.Action("Index", "Home", null, Request.Url.Scheme);
            return View();
          
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
           
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<PartialViewResult> ContactUs(Reservation model)
        {
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                        var message = new MailMessage();
                       
                        
                        lead.Name = model.Name;
                        lead.email = model.email;
                        lead.Number = Convert.ToInt32(model.Phone);
                        lead.message = model.Message;

                        message.To.Add(new MailAddress(model.email));  // replace with valid value 
                        message.From = new MailAddress("swatipateluk23@gmail.com");  // replace with valid value
                        message.Subject = "New Order Catering Order";
                        message.Body = string.Format(body, model.Name, model.email, model.Message);
                        message.IsBodyHtml = true;

                        using (var smtp = new SmtpClient())
                        {
                            var credential = new NetworkCredential
                            {
                                UserName = "swatipateluk23@gmail.com",  // replace with valid value
                                Password = "ganesh9781"  // replace with valid value
                            };
                            smtp.Credentials = credential;
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.EnableSsl = true;
                            await smtp.SendMailAsync(message);
                           
                            var ld = from Lead in dbcontext.Leads select Lead;
                            dbcontext.Leads.Add(lead);

                            dbcontext.SaveChanges();
                            ViewBag.Message = "We have received your Email!We will reply you sortly with your enquiry ";
                            
                           // Response.Write("<h3 class='heading'>" + "We have received your Email!We will reply you sortly with your enquiry" + "</h3>");
                           
                        }
                        return PartialView("ContactUs");
                    }
                    catch (Exception ex)
                    {
                        string exp = ex.ToString();
                        Response.Write("Mail not Sent" + ex);
                    }
                }
                return PartialView("ContactUs");
            }
        }

        [HttpPost]
        public ActionResult MVCMethod()
        {
            return PartialView("_AJAXPartialView");
        }
      
        [HttpPost]
        public ActionResult OrderBreakfast(OrderBreakfast model)
        {
                if (ModelState.IsValid)
                {
                    try
                    {
                        breakfast.OrderType = "BreakFast";
                        breakfast.Items = model.bfppl;
                        breakfast.Name = model.Name1;
                        breakfast.email = model.email1;
                        breakfast.numer = model.Phone1;
                        breakfast.Location = model.Location1;
                        breakfast.Message = model.Message1;

                        dbcontext.tblBreakfasts.Add(breakfast);
                        dbcontext.SaveChanges();
                        //redirect It to thank you page
                        return JavaScript(string.Format("document.location = '{0}';", "Home/Thankyou"));
                        //return PartialView("OrderBreakfast");
                    }
                    catch (Exception ex)
                    {
                        string exp = ex.ToString();
                        Response.Write("Data Does Not inserted" + ex);
                    }
                }
                return PartialView("OrderBreakfast");
        }
        [HttpGet]
        public ActionResult Thankyou()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _OrderBreakfast()
        {
            ViewBag.Message = "breakfastpage";
            return View();
        }

        [HttpPost]
        public ActionResult OrderLunch(OrderLunch model)
        {
                if (ModelState.IsValid)
                {
                    try
                    {
                        breakfast.OrderType = "Lunch";
                        breakfast.Items = model.bfppl;
                        breakfast.Name = model.Name;
                        breakfast.email = model.email;
                        breakfast.numer = model.Phone;
                        breakfast.Location = model.Location;
                        breakfast.Message = model.message;

                        dbcontext.tblBreakfasts.Add(breakfast);
                        dbcontext.SaveChanges();
                        //redirect It to thank you page
                        return JavaScript(string.Format("document.location = '{0}';", "Home/Thankyou"));
                        //return PartialView("OrderBreakfast");
                    }
                    catch (Exception ex)
                    {
                        string exp = ex.ToString();
                        Response.Write("Data Does not inserted" + ex);
                    }
                }
                return PartialView("OrderLunch");    
        }
        [HttpGet]
        public ActionResult _OrderLunch()
        {
            ViewBag.Message = "Lunch";
            return View();
        }

        [HttpPost]
        public ActionResult OrderDinner(OrderBreakfast model)
        {
          
                if (ModelState.IsValid)
                {
                    try
                    {
                        breakfast.OrderType = "Dinner";
                        breakfast.Items = model.bfppl;
                        breakfast.Name = model.Name1;
                        breakfast.email = model.email1;
                        breakfast.numer = model.Phone1;
                        breakfast.Location = model.Location1;
                        breakfast.Message = model.Message1;

                        dbcontext.tblBreakfasts.Add(breakfast);
                        dbcontext.SaveChanges();
                        //redirect It to thank you page
                        return JavaScript(string.Format("document.location = '{0}';", "Home/Thankyou"));
                        //return PartialView("OrderBreakfast");
                    }
                    catch (Exception ex)
                    {
                        string exp = ex.ToString();
                        Response.Write("Order has not been placed" + ex);
                    }
                }
                return PartialView("_OrderDinner");
    
        }
        [HttpGet]
        public ActionResult _OrderDinner()
        {
            ViewBag.Message = "Dinner";
            return View();
        }

    }
}