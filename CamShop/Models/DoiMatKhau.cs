using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CamShop.Models
{
    public class DoiMatKhau
    {
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu cũ")]
        [Required(ErrorMessage = "Nhập mật khẩu cũ")]
        public string OldPassword { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [MinLength(6, ErrorMessage = ("Mật khẩu có ít nhất 6 ký tự"))]
        [MaxLength(20, ErrorMessage = ("Mật khẩu dài nhất 20 ký tự"))]
        [Required(ErrorMessage = "Nhập mật khẩu mới")]
        public string NewPassword { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Nhập họ tên")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Nhập email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Nhập số điện thoại")]
        public string Phone { get; set; }
    }
}