using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlAssignment1.Models
{
    public class Student
    {
        [RegularExpression("1[6-7]+IT[0-9][0-9][1-9]", ErrorMessage = "It Should be like 17IT000")]
        [Required (ErrorMessage ="Id is Required!")] 
        public string ID { get; set; }

        [Required (ErrorMessage = "Name is Required!")]
        [StringLength(30, ErrorMessage ="Maximum Length Should be 30.")]
        public string Name { get; set; }
        
        [Required (ErrorMessage = "Age is Required!")]
        [Range(0, 100, ErrorMessage = "Enter Valid Age")]
        [SourceControlAssignment1.Custom_Validation.AgeValidation(18)]
        public int Age { get; set; }

        [RegularExpression(@"^1[6-7]+IT[0-9][0-9][1-9]@charusat\.edu\.in", ErrorMessage = "It Should be like 17IT001@charusat.edu.in")]
        [Required (ErrorMessage = "Mail is Required!")]
        public string Mail { get; set; }

        
        [RegularExpression(@"[0-9]{10}" , ErrorMessage ="Enter Valid Number")]
        public string Number { get; set; }
        
        [Range(0,10,ErrorMessage ="Enter Between 0 To 10")]
        public decimal? CGPA { get; set; }
        
        [Required (ErrorMessage = "URL is Required!")]
        [Url]
        public string Url { get; set; }
    }
}