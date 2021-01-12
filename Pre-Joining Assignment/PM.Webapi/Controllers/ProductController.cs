using PM.Models.Models;
using PM.Webapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PM.Webapi.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
        public bool Add([FromBody] ProductViewModel pvm)
        {
            using (ProductManagementEntities db = new ProductManagementEntities())
            {
                Products pd = new Products
                {
                    U_Id = pvm.U_Id,
                    P_Name = pvm.P_Name,
                    P_Category = pvm.P_Category.ToString(),
                    P_Price = pvm.P_Price,
                    P_Quantity = pvm.P_Quantity,
                    P_Srt_Desc = pvm.P_Srt_Desc,
                    P_Lng_Desc = pvm.P_Lng_Desc,
                    P_sm_img_path = pvm.P_sm_img_path,
                    P_lg_img_path = pvm.P_lg_img_path
                };
                db.Products.Add(pd);
                db.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public List<ProductViewModel> Details([FromBody] int id)
        {
            using (var context = new ProductManagementEntities())
            {
                List<Products> pd = context.Products.Where(x => x.U_Id == id).ToList();

                List<ProductViewModel> pvm = new List<ProductViewModel>();

                foreach (var item in pd)
                {

                    pvm.Add(new ProductViewModel()
                    {
                        P_Id = item.P_Id,
                        P_Name =item.P_Name,
                        P_Category = item.P_Category,
                        P_Price = item.P_Price,
                        P_Quantity = item.P_Quantity,
                        P_Srt_Desc = item.P_Srt_Desc,
                        P_sm_img_path = item.P_sm_img_path,
                    });

                }

                return pvm;
            }
        }

        [HttpPost]
        public bool Update([FromBody] ProductViewModel pvm)
        {
            using (var context = new ProductManagementEntities())
            {
                Products p = new Products()
                {
                    P_Id = pvm.P_Id,
                    U_Id = pvm.U_Id,
                    P_Name = pvm.P_Name,
                    P_Category = pvm.P_Category,
                    P_Price = pvm.P_Price,
                    P_Quantity = pvm.P_Quantity,
                    P_Srt_Desc = pvm.P_Srt_Desc,
                    P_Lng_Desc = pvm.P_Lng_Desc,
                    P_sm_img_path = pvm.P_sm_img_path,
                    P_lg_img_path = pvm.P_lg_img_path
                };

                Products temp = context.Products.Where(id => pvm.P_Id == id.P_Id).SingleOrDefault();

                temp.P_Id = pvm.P_Id;
                temp.U_Id = pvm.U_Id;
                temp.P_Name = pvm.P_Name;
                temp.P_Category = pvm.P_Category;
                temp.P_Price = pvm.P_Price;
                temp.P_Quantity = pvm.P_Quantity;
                temp.P_Srt_Desc = pvm.P_Srt_Desc;
                temp.P_Lng_Desc = pvm.P_Lng_Desc;
                temp.P_sm_img_path = pvm.P_sm_img_path;
                temp.P_lg_img_path = pvm.P_lg_img_path;

                if(pvm.P_sm_img_path!=null)
                {
                    temp.P_sm_img_path = pvm.P_sm_img_path;
                }
                if(pvm.P_lg_img_path != null)
                {
                    temp.P_lg_img_path = pvm.P_lg_img_path;
                }

                context.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public ProductViewModel Single([FromBody] int P_Id)
        {
            using (var context = new ProductManagementEntities())
            {
                Products pd = context.Products.Where(x => x.P_Id == P_Id).FirstOrDefault();

                ProductViewModel pvm = new ProductViewModel()
                {
                    P_Id = pd.P_Id,
                    U_Id = pd.U_Id,
                    P_Name = pd.P_Name,
                    P_Category = pd.P_Category,
                    P_Price = pd.P_Price,
                    P_Quantity = pd.P_Quantity,
                    P_Srt_Desc = pd.P_Srt_Desc,
                    P_Lng_Desc = pd.P_Lng_Desc,
                    P_sm_img_path = pd.P_sm_img_path,
                    P_lg_img_path = pd.P_lg_img_path
                };

                return pvm;
            }
        }

        [HttpPost]
        public bool Delete([FromBody] int id)
        {
            using (var context = new ProductManagementEntities())
            {
                Products p = context.Products.Where(x => x.P_Id == id).FirstOrDefault();
                context.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return true;
            }

        }



    }
}
