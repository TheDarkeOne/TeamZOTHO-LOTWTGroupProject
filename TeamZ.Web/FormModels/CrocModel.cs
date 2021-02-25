using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamZ.Web.FormModels
{
    public class CrocModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Color too long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Characters are not allowed.")]
        public string Color { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Hobby too long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Characters are not allowed.")]
        public string Hobby { get; set; }

        [StringLength(20, ErrorMessage = "Hat too long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Characters are not allowed.")]
        public string Hat { get; set; }

        [StringLength(20, ErrorMessage = "Tail too long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Characters are not allowed.")]
        public string Tail { get; set; }

        [StringLength(20, ErrorMessage = "Held Item too long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Characters are not allowed.")]
        public string HeldItem { get; set; }
    }
}
