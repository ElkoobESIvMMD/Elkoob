using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace Elkoob.Application.Common.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        // Add List Of Our Sites That Added
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
