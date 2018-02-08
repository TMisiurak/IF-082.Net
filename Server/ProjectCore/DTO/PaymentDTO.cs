using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.DTO
{
    public class PaymentDTO
    {
        
        public int Id { get; set; }
        
        public int PatientId { get; set; }
       
        public int PrescriptionId { get; set; }
        
        public DateTime PaymentDate { get; set; }

        public string PaymentType { get; set; }

        public int sum { get; set; }
    }
}
