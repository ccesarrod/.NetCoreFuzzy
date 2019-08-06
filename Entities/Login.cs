﻿using System.ComponentModel.DataAnnotations;

namespace fuzzy.core.Entities
{
    public class Login
    {
        [Required]
        [Display(Name = "UserName")]
        
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
