using System;
using System.Collections.Generic;
using System.Text;
using ProjectCore.Entities;

namespace BLL.Tests.Stubs.StubData
{
    public static class PrescriptionListUowStubData
    {
        private static List<PrescriptionList> _prescriptionLists;

        public static List<PrescriptionList> PrescriptionLists
        {
            get
            {
                if (_prescriptionLists == null)
                {
                    _prescriptionLists = new List<PrescriptionList>
                    {
                        new PrescriptionList { Id = 201, ProcedureId = 1, DrugId = 1, PrescriptionId = 1},
                        new PrescriptionList { Id = 202, ProcedureId = 2, DrugId = 3, PrescriptionId = 2},
                        new PrescriptionList { Id = 203, ProcedureId = 3, DrugId = 4, PrescriptionId = 3},
                        new PrescriptionList { Id = 204, ProcedureId = 4, DrugId = 5, PrescriptionId = 1},
                        new PrescriptionList { Id = 205, ProcedureId = 5, DrugId = 2, PrescriptionId = 2}
                    };
                }
                return _prescriptionLists;
            }
        }
    }
}
