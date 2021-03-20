﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamZ.Web.FormModels
{
    public class UserModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Username is too long.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Characters are not allowed.")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Password is too long.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Characters are not allowed.")]
        public string Password { get; set; }
    }
}
