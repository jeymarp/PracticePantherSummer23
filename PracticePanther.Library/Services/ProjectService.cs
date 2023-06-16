using PracticePanther.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;
using PracticePanther.Library.DataBase;

namespace PracticePanther.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;
        private static object _lock = new object();
        public static ProjectService? CurrentProj
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }
                }
                return instance;
            }
        }

        private List<Project>? projects;
        private ProjectService()
        {
            projects = new List<Project>();
        }


        public List<Project>? Projects
        {
            get
            {
                return FakeDataBase.Projects;
            }
        }
        public Project? Get(int id)
        {
            return projects?.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Project project)
        {
            if (project != null)
            {
                FakeDataBase.Projects?.Add(project);
            }
        }

        public void Remove(int id)
        {
            var projectToRemove = Get(id);
            if (projectToRemove != null)
            {
                projects?.Remove(projectToRemove);
            }
        }

        public void Remove(Project p)
        {
            Remove(p.Id);
        }

        public void Read()
        {
            foreach (Project project in projects)
            {
                Console.WriteLine("Project details: ");
                Console.WriteLine($"ID: {project.Id}");
                Console.WriteLine($"Name: {project.ShortName}");
                Console.WriteLine($"Notes: {project.LongName}");
                Console.WriteLine($"Open Date: {project.OpenDate}");
                Console.WriteLine($"Project status: {project.IsActive}");
            }
        }
    }
}
