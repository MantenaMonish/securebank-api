using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class JointAccountsDTO
    {
        public int JointMemberId { get; set; }
        public int AccountId { get; set; }
        public int UserId { get; set; }
    }
}