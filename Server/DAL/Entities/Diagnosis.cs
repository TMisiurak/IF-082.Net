using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 100)]
        public string DiagnoseName { get; set; }
        [Required, Range(2, 4000)]
        public string Description { get; set; }
    }
}
