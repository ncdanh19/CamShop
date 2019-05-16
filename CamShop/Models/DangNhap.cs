using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamShop.Models
{
    public class DangNhap
    {
        [Key]
        [Required(ErrorMessage = "Hãy nhập tài khoản")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [Display(Name = "Mật khâir")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}