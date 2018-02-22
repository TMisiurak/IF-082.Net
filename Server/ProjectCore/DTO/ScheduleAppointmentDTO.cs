using System;

namespace ProjectCore.DTO
{
    public class ScheduleAppointmentDTO
    {
        public DateTime TimeSlot { get; set; }
        public bool IsRegistered { get; set; }
    }
}