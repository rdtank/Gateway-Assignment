using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Models.Models
{
    public class ProductViewModel
    {
        public int P_Id { get; set; }
        public int U_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [DisplayName("Product Name")]
        public string P_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Category")]
        [DisplayName("Category")]
        public string P_Category { get; set; }

        [Required(ErrorMessage = "Please Enter Price")]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal P_Price { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity")]
        [DisplayName("Quantity")]
        public int P_Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter Short Description")]
        [DisplayName("Short Description")]
        public string P_Srt_Desc { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Long Description")]
        public string P_Lng_Desc { get; set; }

        [DisplayName("Small Image")]
        public string P_sm_img_path { get; set; }

        [DisplayName("Large Image")]
        public string P_lg_img_path { get; set; }
    }

    //public enum Category
    //{
    //    [Display(Name = "Mobile & Accessories")]
    //    Mobile,
    //    Groceries,
    //    [Display(Name = "Food & Drinks")]
    //    Food,
    //    Fashion,
    //    Other
    //}
}
