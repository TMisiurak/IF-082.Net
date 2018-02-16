using System;
using System.Collections.Generic;
using System.Text;
using ProjectCore.Entities;

namespace BLL.Tests.Stubs.StubData
{
    public static class PrescriptionUowStubData
    {
        private static List<Prescription> _prescriptions;

        public static List<Prescription> Prescriptions
        {
            get
            {
                if (_prescriptions == null)
                {
                    _prescriptions = new List<Prescription>
                    {
                        new Prescription{ Id = 101, DoctorId = 1, PatientId = 1, Description = "tablets",
                            Date = DateTime.Now, DiagnosisId = 1},
                        new Prescription{ Id = 102, DoctorId = 1, PatientId = 1, Description = "tea",
                            Date = DateTime.Now, DiagnosisId = 2},
                        new Prescription{ Id = 103, DoctorId = 1, PatientId = 1, Description = "nimesil",
                            Date = DateTime.Now, DiagnosisId = 3},
                    };
                }
                return _prescriptions;
            }
        }
    }
}
