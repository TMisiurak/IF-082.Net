using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCore.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required]
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }
        
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentType { get; set; }

        public int sum { get; set; }
        
    }
}
