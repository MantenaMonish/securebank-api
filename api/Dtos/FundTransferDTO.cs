using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class FundTransferDTO
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int Months { get; set; }
    }
}