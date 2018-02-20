using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCore.Entities
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required, Range(2, 4000)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public System.DateTime Date { get; set; }
        [Required]
        public int Status { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
