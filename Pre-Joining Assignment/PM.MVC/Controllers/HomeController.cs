using PM.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PM.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:35253/");

                int result = -1;
                try
                {
                    result = request.PostAsync("/api/Auth/Login", model, new JsonMediaTypeFormatter()).Result.Content.ReadAsAsync<int>().Result;
                }
                catch (Exception)
                {

                    throw;
                }
                if (result > 0)
                {
                    FormsAuthentication.SetAuthCookie(result.ToString(), false);
                    // success
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email and Passsword");
                    return View();
                }
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ViewResult SignUp(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var request = new HttpClient())
                {
                    request.BaseAddress = new Uri("http://localhost:35253/");
                    bool result = false;
                    try
                    {
                        result = request.PostAsync("/api/Auth/SignUp", model, new JsonMediaTypeFormatter()).Result.Content.ReadAsAsync<bool>().Result;
                    }
                    catch (Exception)
                    {
                        //error
                    }
                    if (result)
                    {
                        // success
                        return View("Login");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}