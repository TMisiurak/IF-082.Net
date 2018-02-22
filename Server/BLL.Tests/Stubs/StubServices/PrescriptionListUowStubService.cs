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
            await Task.Delay(1);
            return _prescriptionLists;
        }

        public static async Task<PrescriptionList> GetById(int id)
        {
            await Task.Delay(1);
            var prescriptionList = _prescriptionLists.FirstOrDefault(u => u.Id == id);
            return prescriptionList;
        }

        public static async Task<int> DeleteById(int id)
        {
            await Task.Delay(1);
            var obj = _prescriptionLists.FirstOrDefault(u => u.Id == id);
            int index = _prescriptionLists.IndexOf(obj);
            _prescriptionLists.RemoveAt(index);
            return index;
        }

        public static async Task<int> Update(PrescriptionList prescriptionListTest)
        {
            await Task.Delay(1);
            var obj = _prescriptionLists.FirstOrDefault(u => u.Id == prescriptionListTest.Id);
            int index = _prescriptionLists.IndexOf(obj);
            _prescriptionLists[index] = prescriptionListTest;
            return index;
        }

        public static async Task<int> Create(PrescriptionList prescriptionListTest)
        {
            await Task.Yield();
            await Task.Delay(1);
            _prescriptionLists.Add(prescriptionListTest);
            int result = _prescriptionLists.Count;
            return result;
        }
    }
}
