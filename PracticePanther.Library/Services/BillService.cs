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
            bills = new List<Bill>();
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

    }
}
