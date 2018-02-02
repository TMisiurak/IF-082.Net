using System.Collections.Generic;

namespace BLL.DTO
{
    public class DiagnosisDTO
    {
        public int Id { get; set; }
        public string DiagnosisName { get; set; }
        public string Description { get; set; }

        public List<PrescriptionDTO> Prescriptions { get; set; }
    }
}
