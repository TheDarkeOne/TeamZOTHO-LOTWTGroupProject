﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamZ.Web.FormModels
{
    public class ItemModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Name is too long.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Characters are not allowed.")]
        public string ItemName { get; set; }

        [Required]
        [Range(0.00, 1000.00, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [RegularExpression(@"^[0-9.]+$", ErrorMessage = "Characters are not allowed.")]
        public decimal Price { get; set; }

        [StringLength(50, ErrorMessage = "Description is too long.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Characters are not allowed.")]
        public string Description { get; set; }
    }
}
