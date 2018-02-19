using System;

namespace ProjectCore.DTO
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public DateTime WorkStart { get; set; }
        public int TimeSlotCount { get; set; }
        public int SlotDuration { get; set; }
        public DateTime BreakStart { get; set; }
        public int BreakDuration { get; set; }
        public int Weekday { get; set; }
        public int ValidityPeriod { get; set; }
        public int DoctorId { get; set; }
    }
}