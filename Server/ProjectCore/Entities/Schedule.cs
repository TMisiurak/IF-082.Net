using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectCore.Entities
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        [Required, Column(TypeName = "time(0)")]
        public TimeSpan WorkStart { get; set; }
        [Required]
        public int TimeSlotCount { get; set; }
        [Required]
        public int SlotDuration { get; set; }
        [Required, Column(TypeName = "time(0)")]
        public TimeSpan BreakStart { get; set; }
        [Required]
        public int BreakDuration { get; set; }
        [Required]
        public int Weekday { get; set; }
        [Required]
        public int ValidityPeriod { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}