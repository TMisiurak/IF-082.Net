using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Entities
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 100)]
        public string DiagnosisName { get; set; }
        [Required, Range(2, 4000)]
        public string Description { get; set; }

        public List<Prescription> Prescriptions { get; set; }
    }
}
