using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Tests.Stubs.StubData;
using ProjectCore.Entities;

namespace BLL.Tests.Stubs.StubServices
{
    public static class PrescriptionListUowStubService
    {
        private static List<PrescriptionList> _prescriptionLists = PrescriptionListUowStubData.PrescriptionLists;

        public static async Task<IList<PrescriptionList>> GetAll()
        {
            await Task.Yield();
            return _prescriptionLists;
        }

        public static async Task<PrescriptionList> GetById(int id)
        {
            await Task.Yield();
            var prescriptionList = _prescriptionLists.FirstOrDefault(u => u.Id == id);
            return prescriptionList;
        }
    }
}
