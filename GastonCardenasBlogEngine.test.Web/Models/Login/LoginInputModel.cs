using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GastonCardenasBlogEngine.test.Web.Models.Login
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "{0} field is required")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
