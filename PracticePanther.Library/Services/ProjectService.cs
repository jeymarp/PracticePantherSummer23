using PracticePanther.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class ProjectService
    {
        private List<Project> projects;
        public List<Project> Projects
        {
            get
            {
                return projects;
            }
        }

        private static ProjectService? instance;
        public static ProjectService? Current
        {

            get
            {
                if (instance == null)
                {
                    instance = new ProjectService();
                }

                return instance;
            }
        }

        private ProjectService()
        {
            projects = new List<Project>();
        }

        public Project? Get(int id)
        {
            return Projects?.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Project project)
        {
            if (project.Id == 0)
            {
                //add
                project.Id = LastId + 1;
                project.OpenDate = DateTime.Now;
            }
            projects.Add(project);
        }

        public void Edit(Project project)
        {
            Project? existingProj = Get(project.Id);
            if(existingProj != null)
            {
                existingProj.IsActive = project.IsActive;
                existingProj.LongName = project.LongName;
                existingProj.OpenDate = project.OpenDate;
            }
        }

        private int LastId
        {
            get
            {
                return Projects.Any() ? Projects.Select(c => c.Id).Max() : 0;
            }
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

        public void Delete(Project p)
        {
            Delete(p.Id);
        }

        public void Delete(int id)
        {
            var projectToRemove = Projects.FirstOrDefault(p => p.Id == id);
            if (projectToRemove != null)
            {
                Projects?.Remove(projectToRemove);
            }
        }

        public void CloseProject(Project p)
        {
            CloseProject(p.Id);
        }

        public void CloseProject(int id)
        {
            var projectToClose = Projects.FirstOrDefault(p => p.Id == id);
            if (projectToClose != null)
            {
                Projects?.Remove(projectToClose);
                
            }
        }

    }
}
