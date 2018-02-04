using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Patient 
    {
        [Key]
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
