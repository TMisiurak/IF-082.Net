using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Entities
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 100)]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }

        public Doctor Doctor { get; set; }
    }
}
