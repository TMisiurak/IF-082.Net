using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDiagnosisService
    {
        void CreateDiagnosis(DiagnosisDTO diagnosisDTO);
        DiagnosisDTO GetDiagnosisById(int? id);
        IEnumerable<DiagnosisDTO> GetDiagnosis();
        void Dispose();
    }
}
