﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Source_Control_Assignment.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        public string Image { get; set; }
    }
}