using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Auth
{
    public class RegisterDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }
        public string Address { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
    }
}