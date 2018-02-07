using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Entities
{
    public class Procedure
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 120)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Room { get; set; }
    }
}
