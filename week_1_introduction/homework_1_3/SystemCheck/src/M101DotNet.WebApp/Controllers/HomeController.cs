using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M101DotNet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var i = 0;
            for (var bit = 0; bit < 32; bit++)
            {
                i |= bit << bit;
            }

            ViewBag.Message = i.ToString();
            return View();
        }
    }
}