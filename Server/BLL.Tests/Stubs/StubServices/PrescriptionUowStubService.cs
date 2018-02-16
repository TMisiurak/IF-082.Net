using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Tests.Stubs.StubData;
using ProjectCore.Entities;

namespace BLL.Tests.Stubs.StubServices
{
    public static class PrescriptionUowStubService
    {
        private static List<Prescription> _prescriptions = PrescriptionUowStubData.Prescriptions;

        public static async Task<IList<Prescription>> GetAll()
        {
            await Task.Yield();
            return _prescriptions;
        }

        public static async Task<Prescription> GetById(int id)
        {
            await Task.Yield();
            var prescription = _prescriptions.FirstOrDefault(u => u.Id == id);
            return prescription;
        }
    }
}
