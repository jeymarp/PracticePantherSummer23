using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    internal class ProjectDetailViewModel
    {
        public ProjectDetailViewModel()
        {
            project = new Project();
        }

        public string ShortName
        {
            get => project?.ShortName ?? string.Empty;
            set { if (project != null) project.ShortName = value; }
        }

        public string LongName
        {
            get => project?.LongName ?? string.Empty;
            set { if (project != null) project.LongName = value; }
        }

        public int Id { get; set; }

        private Project project;

        public void AddProject(Shell s)
        {
            ProjectService.CurrentProj.Add(project);
            s.GoToAsync("//Project");
        }
    }
}
