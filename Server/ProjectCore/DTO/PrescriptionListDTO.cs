using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.DTO
{
    public class PrescriptionListDTO
    {
        public int Id { get; set; }
        public int ProcedureId { get; set; }
        public int DrugId { get; set; }
        public int PrescriptionId { get; set; }
    }
}

