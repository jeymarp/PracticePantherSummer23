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
            _times = new List<Time>();

        }

        public List<Time>? Times => _times;

        public void Add(Time time)
        {
            if (time.ProjectId == 0)
                return;

            var proj = ProjectService.Current.Get(time.ProjectId);
            if (proj == null)
            {
                return;
            }
            time.TimeId = LastId + 1;
            _times?.Add(time);

        }


        public void Update(Time time)
        {
            //finding time entry to update 
            //Time? existingTime = _times?.FirstOrDefault(t => t.ProjectId == time.ProjectId && 
            //                       t.EmployeeId == time.EmployeeId);
            Time? existingTime = _times?.FirstOrDefault(t => t.ProjectId == time.ProjectId);


            if (existingTime != null)
            {
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

        //public IEnumerable<Time> Search(string query)
        //{
        //    if (DateTime.TryParse(query, out DateTime searchDate))
        //    {
        //        return Times.Where(t => t.Date.Date == searchDate.Date);
        //    }

        //    // Return an empty collection if the query cannot be parsed as a valid date
        //    return Enumerable.Empty<Time>();
        //}


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

    }
}
