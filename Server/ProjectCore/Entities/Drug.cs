using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Entities
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(2, 200)]
        public string DrugName { get; set; }

        public IList<PrescriptionList> PrescriptionLists { get; set; }
    }
}
