using System;
using System.Collections.Generic;
using System.Text;

namespace library.Models.Auth
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
