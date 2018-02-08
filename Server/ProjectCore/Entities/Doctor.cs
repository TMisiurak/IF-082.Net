using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectCore.Entities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int YearsExp { get; set; }

        [Required, Range(2, 100)]
        public string Speciality { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
