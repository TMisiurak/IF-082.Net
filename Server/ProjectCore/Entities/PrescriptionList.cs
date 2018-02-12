using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectCore.Entities
{
    public class PrescriptionList
    {
        [Key]
        public int Id { get; set; }

        // foreign key
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        // foreign key
        public int DrugId { get; set; }
        public Drug Drug { get; set; }

        // foreign key
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
    }

}
