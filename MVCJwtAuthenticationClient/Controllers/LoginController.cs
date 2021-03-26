using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCJwtAuthenticationClient.Models;
using Newtonsoft.Json;

namespace MVCJwtAuthenticationClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDetails l)
        {
            //string token;
            LoginDetails obj = new LoginDetails();
            using (var httpClient = new HttpClient())
            {
                ViewBag.message = "";

                StringContent content = new StringContent(JsonConvert.SerializeObject(l), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44388/api/Login/AuthenicateUser/", content))
                {
                  

                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        ViewBag.message = "Invalid User";
                       
                    }
                    else
                    {
                        ViewBag.message = "Success";
                    }
                }

            }
            return View();



        }

    }
}
