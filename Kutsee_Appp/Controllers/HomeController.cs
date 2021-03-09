using Kutsee_Appp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutsee_Appp.Controllers
{
   
    public class HomeController : Controller
    {
        Guest gu;
        string emlid;

        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 4 && hour < 12)
            {
                ViewBag.Greeting = "Tere hommikust";
            }
            else if (hour >= 12 && hour < 16)
            {
                ViewBag.Greeting = "Tere päevast";
            }
            else if (hour >= 16 && hour < 23)
            {
                ViewBag.Greeting = "Tere õhtust";
            }
            else if (hour == 23 || hour < 4)
            {
                ViewBag.Greeting = "Head ööd";
            }
            
            return View();
           
        }

        [HttpGet]
        public ActionResult Questionnaire()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Questionnaire(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
        
        public ViewResult Thanks()
        {
            WebMail.Send(gu.Email, "Meeldetuletus", gu.Name + ", Ära unusta ootame Teid peos!. Pidu toimub 22.01.21. Sind ootavad väga!");
            return View();
        }
        

        private void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "aani66407@gmail.com";
                WebMail.Password = "janika12345";
                WebMail.From = "aani66407@gmail.com";
                WebMail.Send("aani66407@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }
        }
    }
}