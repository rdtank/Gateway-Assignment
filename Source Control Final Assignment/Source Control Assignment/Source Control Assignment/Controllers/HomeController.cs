using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Source_Control_Assignment.Models;

namespace Source_Control_Assignment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string id = Session["userId"].ToString();
            var model = UserDetails(int.Parse(id));
            return View(model);
        }

        public UserModel UserDetails(int id)
        {
            using (var context = new UserDBEntities())
            {
                var result = context.User
                    .Where(x =>x.Id == id)
                    .Select(x => new UserModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Username = x.Username,
                        Mail = x.Email,
                        Phone = x.Phone,
                        Age = x.Age,
                        Image = x.Image
                    }).FirstOrDefault();
                return result;
            }
        }
    }
}