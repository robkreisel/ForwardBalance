using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Models
{
    public class BankForCreationDto
    {
        [Required(ErrorMessage = "Bank name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public int RoutingNumber { get; set; }
        public bool IsHidden { get; set; }
        
        public ICollection<AccountDto> Accounts { get; set; }
        = new List<AccountDto>();
    }
}
