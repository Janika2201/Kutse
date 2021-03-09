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
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind minu peole! Palun tule!!!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust!" : "Tere päevast!";
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
            if (ModelState.IsValid) { return View("Thanks", guest); }
            else
            { return View(); }
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
        


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private string Tervis(DateTime dateTime)
        {
            int hour = dateTime.Hour;
            return hour switch
            {
                >= 4 and < 12 => "Tere hommikust",
                >= 12 and < 17 => "Tere päevast",
                >= 17 and < 23 => "Tere õhtust",
                _ => "Head ööd"
            };
        }
    }
}