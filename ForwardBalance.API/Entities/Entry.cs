using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForwardBalance.API.Entities
{
    public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public int AccountId { get; set; }
        //[ForeignKey("RelatedEntryId")]
        //public Entry RelatedEntry { get; set; }
        public int RelatedEntryId { get; set; }
    }
}
