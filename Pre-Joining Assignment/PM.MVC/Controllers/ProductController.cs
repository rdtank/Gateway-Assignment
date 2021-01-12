using PM.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;

namespace PM.MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add_Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Product(ProductViewModel pvm, HttpPostedFileBase smImg, HttpPostedFileBase lgImg)
        {
            if (ModelState.IsValid)
            {
                string smImgPath = Smuploadimage(smImg);
                string lgImgPath = Lguploadimage(lgImg);

                pvm.P_sm_img_path = smImgPath;
                pvm.P_lg_img_path = lgImgPath;

                using (var request = new HttpClient())
                {
                    request.BaseAddress = new Uri("http://localhost:35253/");

                    bool result = false;
                    try
                    {
                        pvm.U_Id = int.Parse(User.Identity.Name);
                        result = request.PostAsync("/api/Product/Add", pvm, new JsonMediaTypeFormatter()).Result.Content.ReadAsAsync<bool>().Result;
                    }
                    catch (Exception)
                    {
                        //error
                    }
                    if (result)
                    {
                        ModelState.Clear();
                        // success
                        return View();
                    }
                    else
                    {
                        //error
                        return View();
                    }
                }
            }
            return View();
        }

        public string Smuploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = null;
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Images/smImg"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Images/smImg/" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception)
                    {
                        path = null;
                    }
                }
                else
                {
                    Response.Write("<script>alert('jpg, jpeg and png formats are allowed.');</script>");
                }
            }
            else
            {
                path = null;
            }
            return path;
        }
        public string Lguploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = null;
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Images/lgImg"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Images/lgImg/" + random + Path.GetFileName(file.FileName);
                    }
                    catch (Exception)
                    {
                        path = null;
                    }
                }
                else
                {
                    Response.Write("<script>alert('jpg, jpeg and png formats are allowed.');</script>");
                }
            }
            else
            {
                path = null;
            }
            return path;
        }

        public ActionResult Product_List()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Detail()
        {
            List<ProductViewModel> response = null;

            using (var request =  new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:35253/");

                try
                {
                    int id = int.Parse(User.Identity.Name);

                    response = request.PostAsync("/api/Product/Details", id, new JsonMediaTypeFormatter()).Result.Content.ReadAsAsync<List<ProductViewModel>>().Result;

                    ViewBag.Prod = response;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return Json(new { data = response }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int P_Id)
        {
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:35253/");
                bool result = false;

                try
                {

                    result = request.PostAsync("/api/Product/Delete", P_Id,new JsonMediaTypeFormatter()).Result.Content.ReadAsAsync<bool>().Result;
                }
                catch (Exception)
                {
                    // error
                    throw;
                }

                if (result)
                {
                    return RedirectToAction("Product_List");
                }
                else
                {
                    // Error
                    return RedirectToAction("Product_List");
                }
            }
        }

        public ActionResult Update(int P_Id)
        {
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:35253/");
                ProductViewModel result = null;

                try
                {

                    result = request.PostAsync("/api/Product/Single", P_Id,new JsonMediaTypeFormatter()).Result.Content.ReadAsAsync<ProductViewModel>().Result;
                    return View(result);
                }
                catch (Exception)
                {
                    // error
                    throw;
                }

            }
        }

        [HttpPost]
        public ActionResult Update(ProductViewModel pvm)
        {
            using (var request = new HttpClient())
            {
                request.BaseAddress = new Uri("http://localhost:35253/");
                bool result = false;

                try
                {

                    result = request.PostAsync("/api/Product/Update", pvm,new JsonMediaTypeFormatter()).Result.Content.ReadAsAsync<bool>().Result;
                    return RedirectToAction("Product_List");
                }
                catch (Exception)
                {
                    // error
                    throw;
                }


            }
        }
    }
}