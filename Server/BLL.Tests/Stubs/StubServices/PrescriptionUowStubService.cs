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
            await Task.Delay(1);
            return _prescriptions;
        }

        public static async Task<Prescription> GetById(int id)
        {
            await Task.Delay(1);
            var prescription = _prescriptions.FirstOrDefault(u => u.Id == id);
            return prescription;
        }

        public static async Task<int> DeleteById(int id)
        {
            await Task.Delay(1);
            var obj = _prescriptions.FirstOrDefault(u => u.Id == id);
            int index = _prescriptions.IndexOf(obj);
            _prescriptions.RemoveAt(index);
            return index;
        }

        public static async Task<int> Update(Prescription prescriptionTest)
        {
            await Task.Delay(1);
            var obj = _prescriptions.FirstOrDefault(u => u.Id == prescriptionTest.Id);
            int index = _prescriptions.IndexOf(obj);
            _prescriptions[index] = prescriptionTest;
            return index;
        }

        public static async Task<int> Create(Prescription prescriptionTest)
        {
            await Task.Delay(1);
            _prescriptions.Add(prescriptionTest);
            int result = _prescriptions.Count;
            return result;
        }
    }
}
