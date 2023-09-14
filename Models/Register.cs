﻿using System.ComponentModel.DataAnnotations;

namespace QuanLyPhanTuWeb.Models
{
    public class Register
    {
        [Required, EmailAddress]
        public string email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "mat khau khong duoc duoi 6 ki tu!")]
        public string passwordHash { get; set; } = string.Empty;
        [Required, Compare("passwordHash")]
        public string repasswordHash { get; set; } = string.Empty;
    }
}
