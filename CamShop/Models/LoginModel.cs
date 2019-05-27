using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamShop.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Điền tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage ="Điền mật khẩu")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}