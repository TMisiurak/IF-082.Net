using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int DiagnosisId { get; set; }
        public DiagnosisDTO Diagnosis { get; set; }
    }
}
