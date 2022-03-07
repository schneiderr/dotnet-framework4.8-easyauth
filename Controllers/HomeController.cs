using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Tokens.Jwt;

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

            var token = Request.Headers["X-MS-TOKEN-AAD-ID-TOKEN"];
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;

                ViewBag.SecurityToken = tokenS.Payload;
            }

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