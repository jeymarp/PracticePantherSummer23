using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class TimeService
    {
        private static TimeService? _instance;
        private List<Time>? _times;
        public static TimeService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TimeService();
                }
                return _instance;
            }
        }

        private TimeService()
        {
            _times = new List<Time> {
                new Time{TimeId = 1, EmployeeId = 1, ProjectId = 1, Hours=1.75M, Narrative = "TEST"}
            };

        }

        public List<Time>? Times => _times;

        public void Add(Time time)
        {
            if (time.ProjectId == 0 && time.EmployeeId == 0)
                return;

            var proj = ProjectService.Current.Get(time.ProjectId);
            if (proj == null)
            {
                return;
            }
            var emp = EmployeeService.Current.Get(time.EmployeeId);   //adding EmployeeId to the condition
            if (emp == null)
            {
                return;
            }
            time.TimeId = LastId + 1;
            time.Date = DateTime.Now;
            _times?.Add(time);

        }


        public void Update(Time time)
        {
            //finding time entry to update
            Time? existingTime = _times?.FirstOrDefault(t => t.ProjectId == time.ProjectId &&
                                   t.EmployeeId == time.EmployeeId);

            if (existingTime != null)
            {
                DateTime originalEntryDate = existingTime.Date;

                existingTime.Date = originalEntryDate;
                existingTime.Date = time.Date;
                existingTime.Narrative = time.Narrative;
                existingTime.Hours = time.Hours;
                existingTime.ProjectId = time.ProjectId;
                existingTime.EmployeeId = time.EmployeeId;
            }
        }

        public void Delete(Time time)
        {
            _times?.Remove(time);
        }

        //-----------------------------------------------------
        public int GetProjectId(int projectId)
        {
            if (Times != null)
            {
                var time = Times.FirstOrDefault(t => t.ProjectId == projectId);
                if (time != null)
                {
                    return time.ProjectId;
                }
            }
            return 0;
        }

        public Time? Get(int id)
        {
            return _times.FirstOrDefault(t => t.TimeId == id);
        }

        private int LastId
        {
            get
            {
                return Times.Any() ? Times.Select(t => t.TimeId).Max() : 0;
            }
        }

        //----------------------------------------------------------------------------------
        //New code to extend the time functionality
        public int GetEmployeeId(int employeeId)
        {
            if (Times != null)
            {
                var time = Times.FirstOrDefault(t => t.EmployeeId == employeeId);
                if (time != null)
                {
                    return time.EmployeeId;
                }
            }
            return 0;
        }
    }
}
