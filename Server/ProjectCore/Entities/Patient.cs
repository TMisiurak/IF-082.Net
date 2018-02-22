using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Entities
{
    public class Patient 
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public ICollection<Payment> Payment { get; set; }
    }
}
