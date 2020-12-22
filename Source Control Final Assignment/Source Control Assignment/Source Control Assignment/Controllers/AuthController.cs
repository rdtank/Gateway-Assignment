using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Source_Control_Assignment.Models;
using System.Web.Security;
using System.IO;
using log4net;

namespace Source_Control_Assignment.Controllers
{
    public class AuthController : Controller
    {
        public static log4net.ILog Log { get; set; }

        ILog log = log4net.LogManager.GetLogger(typeof(AuthController));
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            log.Debug("Login Attempt");
            using (var context = new UserDBEntities())
            {
                bool isvalid = context.User.Any(x => x.Username == model.Username && x.Password == model.Password);
                if (isvalid)
                {
                    log.Debug("Authorized Successful");
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    Session["userId"] = context.User.Where(x => x.Username == model.Username).FirstOrDefault().Id;
                    log.Debug("Redirect to Dashboard");
                    return RedirectToAction("Index", "Home");
                }
                log.Error("User Not Authorized");
                ModelState.AddModelError("", "Invalid Username and Passsword");
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel model, HttpPostedFileBase imgfile)
        {
            log.Debug("Register Attempt");
            if (ModelState.IsValid)
            {
                int id = AddUser(model, imgfile);
                if (id > 0)
                {
                    ModelState.Clear();
                    log.Debug("Redirect to Dashboard");
                    return RedirectToAction("Login");
                }
            }
            log.Error("Validation Errors");
            return View("Register");
        }

        public int AddUser(UserModel model, HttpPostedFileBase imgfile)
        {
            log.Debug("New User Added");
            using (var context = new UserDBEntities())
            {
                string path = uploadimage(imgfile);
                User user = new User()
                {
                    Name = model.Name,
                    Username = model.Username,
                    Email = model.Mail,
                    Password = model.Password,
                    Phone = model.Phone.ToString(),
                    Age = model.Age.ToString(),
                    Image = path

                };
                context.User.Add(user);
                context.SaveChanges();
                log.Debug("User Details stored on Database");
                return user.Id;
            }
        }

        public string uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('jpg, jpeg and png formats are allowed.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please Select a File');</script>");
                path = "-1";
            }
            return path;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}