using System;

namespace ProjectCore.DTO
{
    public class PrescriptionDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int DiagnosisId { get; set; }
        public int AppointmentId { get; set; }
    }
}
