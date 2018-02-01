using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 200)]
        public string DrugName { get; set; }
    }
}
