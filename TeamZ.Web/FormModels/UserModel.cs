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
        [StringLength(20, ErrorMessage = "Username is too long.")]
        [RegularExpression(@"^[a-zA-Z0-9_@.$]*$", ErrorMessage = "Contains characters not allowed.")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password is too long.")]
        [RegularExpression(@"^[a-zA-Z0-9@$!?]*$", ErrorMessage = "Contains characters not allowed.")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}
