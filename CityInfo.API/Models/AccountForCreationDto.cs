using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Models
{
    public class AccountForCreationDto
    {
        [Required(ErrorMessage = "Account name is required")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public int AccountNumber { get; set; }
    }
}
