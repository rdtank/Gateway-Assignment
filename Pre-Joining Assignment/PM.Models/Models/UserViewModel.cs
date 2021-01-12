using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Models.Models
{
    public class UserViewModel
    {
        public int U_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [DisplayName("Username")]
        [MaxLength(30, ErrorMessage = "Username is too Long")]
        public string U_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Enter Valid Email")]
        [DisplayName("Email")]
        public string U_Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string U_Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("U_Password", ErrorMessage = "Password Not Match")]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string U_CPassword { get; set; }
    }
}
