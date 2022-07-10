using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.ViewModels
{
    public class RegisterUserViewModel
    {
        [MinLength(10)]
        [MaxLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
