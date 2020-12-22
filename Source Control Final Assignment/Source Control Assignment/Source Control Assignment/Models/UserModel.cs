using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Source_Control_Assignment.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(30)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Userame is Required!")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Mail is Required!")]
        [EmailAddress]
        public string Mail { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [RegularExpression(@"[0-9]{10}", ErrorMessage = "Enter Valid Number")]
        public string Phone { get; set; }
        
        [Range(18, 100, ErrorMessage = "Age Shoud be Between 18 to 100")]
        public string Age { get; set; }
        
        [FileExtensions(Extensions = "jpg,jpeg,png", ErrorMessage = "Upload valid File!")]
        public string Image { get; set; }
    }
}