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
                //default list only for test purposes, delete later
                new Bill {DueDate = DateTime.Now, ProjectId = 1},
                new Bill {DueDate = DateTime.Now, ProjectId = 2},
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

        public List<Bill> GetBillsForProject(Project project)
        {
            return project.Bills;
        }

        public List<Bill> GetBillsForClient(Client client)
        {
            List<Bill> allBills = new List<Bill>();

            List<Project>? projects = client.Projects;
            foreach (var project in projects)
            {
                allBills.AddRange(project.Bills);
            }

            return allBills;
        }

        public IEnumerable<Bill> Search(string query)
        {
            return Bills
                .Where(c => c.DueDate.ToString().ToUpper()
                    .Contains(query.ToUpper()));
        }

    }
}
