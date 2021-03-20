using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamZ.Web.FormModels
{
    public class LoginModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Username too long.")]
        [RegularExpression(@"^[a-zA-Z0-9_@.$]*$", ErrorMessage = "Contains characters not allowed.")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password too long.")]
        [RegularExpression(@"^[a-zA-Z0-9@$!?]*$", ErrorMessage = "Contains characters not allowed.")]
        public string Password { get; set; }
    }
}
