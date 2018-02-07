using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Entities
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2,200)]
        public string Name { get; set; }
        [Required, Range(2, 300)]
        public string Address { get; set; }

        public List<Department> Departments { get; set; }
    }
}
