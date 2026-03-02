using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class AccountCreateDTO
    {
        public string AccountNumber { get; set; } = string.Empty;
        public int AccountTypeId { get; set; }
        public decimal Balance { get; set; }
        public bool IsJointAccount { get; set; }
        public int UserId { get; set; }
        
    }
}