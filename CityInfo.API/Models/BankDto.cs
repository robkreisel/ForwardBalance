using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Models
{
    public class BankDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoutingNumber { get; set; }
        public int NumberOfAccounts
        {
            get
            {
                return Accounts.Count;
            }
        }
        public ICollection<AccountDto> Accounts { get; set; }
        = new List<AccountDto>();
    }
}
