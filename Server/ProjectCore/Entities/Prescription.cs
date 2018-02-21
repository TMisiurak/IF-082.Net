using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCore.Entities
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required, MaxLength(4000)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        [Required]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public virtual Payment Payment { get; set; }

        public IList<PrescriptionList> PrescriptionLists { get; set; }
    }
}
