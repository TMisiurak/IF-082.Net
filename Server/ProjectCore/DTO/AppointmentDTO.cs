using System;

namespace ProjectCore.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}
