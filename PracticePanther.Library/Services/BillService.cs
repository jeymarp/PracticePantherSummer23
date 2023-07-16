using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class BillService
    {
        public List<Bill> bills;
        public List<Bill> Bills
        {
            get
            {
                return bills;
            }
        }
        private static BillService? instance;
        public static BillService? Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillService();
                }
                return instance;

            }
        }

        private BillService()
        {
            bills = new List<Bill>
            {
                new Bill() {ProjectId = 1, TotalAmount = 45 }
            };
        }

        //test
        public Bill? Get(DateTime dueDate)
        {
            return Bills.FirstOrDefault(b => b.DueDate == dueDate);
        }

        public Bill? GetId(int id)
        {
            return Bills?.FirstOrDefault(b => b.BillId == id);
        }

        public List<Bill> GetBillByProjectId(int projectId)
        {
            return Bills.Where(b => b.ProjectId == projectId).ToList(); ;
        }

        public List<Bill> GetBillsForClientAndProject(int clientId, int projectId)
        {
            return Bills.Where(b => b.ClientId == clientId && b.ProjectId == projectId).ToList();
        }

        public IEnumerable<Bill> Search(string query)
        {
            return Bills
                .Where(c => c.DueDate.ToString().ToUpper()
                    .Contains(query.ToUpper()));
        }

        //new
        public void Add(Bill bill)
        {
            if (bill == null)
                throw new ArgumentNullException(nameof(bill));

            bills.Add(bill);
        }

    }
}
