using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Azure.Identity;
using Azure.Core;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EasyAuthPOC.Controllers
{
    public class RFPController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetAsync(int auth = 1)
        {

            var httpClient = new HttpClient();

            try
            {
                if (auth == 1)
                {
                    var azureCredential = new DefaultAzureCredential();
                    var context = new TokenRequestContext(
                        new string[] { "https://rfp-easyauth-webapp-poc.azurewebsites.net/" });

                    var token = await azureCredential.GetTokenAsync(context);

                    // Specify the access token in the Authorization header
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                }

                // The actual request to the secured "integration" API
                var result = await httpClient.GetStringAsync(
                    "https://rfp-easyauth-webapi-poc.azurewebsites.net/api/rfp");

                return Json($"Call to 'API' succeeded. Response from 'Integration': {result}");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
                //return new HttpStatusCodeResult(500, $"Exception: {ex.Message}\n\nStack trace:\n{ex.StackTrace}");
            }
        }

        public async Task<ActionResult> Token()
        {

            var httpClient = new HttpClient();
             var azureCredential = new DefaultAzureCredential();
            var context = new TokenRequestContext(
                new string[] { "https://rfp-easyauth-webapi-poc.azurewebsites.net/" });

            var token = await azureCredential.GetTokenAsync(context);

            // Specify the access token in the Authorization header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);           
            return Json(token);
        }
    }
}