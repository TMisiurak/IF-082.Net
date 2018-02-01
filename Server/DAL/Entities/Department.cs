using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 100)]
        public string Name { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
