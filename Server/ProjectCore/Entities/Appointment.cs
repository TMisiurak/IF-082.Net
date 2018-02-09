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
        // TODO: fix this fkey when implemented
        //[Required]
        public int DoctorId { get; set; }
        [Required, Range(2, 4000)]
        public string Description { get; set; }
        [Required, Column(TypeName = "date")]  // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime Date { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int CabinetId { get; set; }
        [Required]
        public int PrescriptionId { get; set; }
    }
}
