using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Models
{
    public class BankWithoutAccountsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoutingNumber { get; set; }
        public bool IsHidden { get; set; }
    }
}
