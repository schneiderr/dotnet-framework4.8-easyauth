using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyAuthPOC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.IDToken = Request.Headers["X-MS-TOKEN-AAD-ID-TOKEN"] ?? "No token exist";
            ViewBag.AccessToken = Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"] ?? "No access token exist";
            ViewBag.ExpiresOn = Request.Headers["X-MS-TOKEN-AAD-EXPIRES-ON"] ?? "No expiration token exist";
            ViewBag.RefreshToken = Request.Headers["X-MS-TOKEN-AAD-REFRESH-TOKEN"] ?? "No refresh token exist";

            return View();
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
    }
}