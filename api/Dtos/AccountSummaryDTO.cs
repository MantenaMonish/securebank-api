using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class AccountSummaryDTO
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountTypeName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool IsJointAccount { get; set; }
    }
}