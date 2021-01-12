using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PM.Models.Models;
using PM.Webapi.Models;

namespace PM.Webapi.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        public int Login([FromBody] UserViewModel uvm)
        {
            var email = uvm.U_Email;
            var password = uvm.U_Password;

            using (ProductManagementEntities db = new ProductManagementEntities())
            {
                Users userobj = db.Users.Where(user => user.U_Email == email && user.U_Password == password).FirstOrDefault();
                if (userobj != null)
                {
                    return userobj.U_Id;
                }
                else
                {
                    return -1;
                }
            }
        }

        [HttpPost]
        public bool SignUp([FromBody] UserViewModel uvm)
        {
            var name = uvm.U_Name;
            var email = uvm.U_Email;
            var password = uvm.U_Password;
            var cpassword = uvm.U_CPassword;

            using (ProductManagementEntities db = new ProductManagementEntities())
            {
                if (db.Users.Any(user => user.U_Email == email))
                {
                    return false;
                }
                Users temp = new Users { U_Name=name, U_Email = email, U_Password = password };
                db.Users.Add(temp);
                db.SaveChanges();
                return true;
            }
        }
    }
}
