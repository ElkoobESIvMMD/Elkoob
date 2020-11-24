using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Elkoob.Application.Common.ViewModels.Identity
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری خود را وارد کنید")]
        [Remote("IsUserNameInUse", "Account", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید")]
        [DataType(DataType.EmailAddress)]
        [Remote("IsEmailInUse", "Account", HttpMethod = "POST",
            AdditionalFields = "__RequestVerificationToken")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "لطفا رمز عبور خود را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "لطفا تکرار رمز عبور خود را وارد کنید")]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
