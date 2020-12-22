using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Source_Control_Assignment.Models;
using log4net;

namespace Source_Control_Assignment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static log4net.ILog Log { get; set; }

        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        // GET: Home
        public ActionResult Index()
        {
            log.Debug("User Dashboard");
            string id = Session["userId"].ToString();
            var model = UserDetails(int.Parse(id));
            return View(model);
        }

        public UserModel UserDetails(int id)
        {
            log.Debug("Get Userdata from Database");
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