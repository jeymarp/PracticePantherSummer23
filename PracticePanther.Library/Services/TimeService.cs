using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.Services
{
    public class TimeService
    {
        private static TimeService? _instance;
        private List<Time>? _times;
        public static TimeService CurrentTime
        {
            get
            {
                if(_instance == null)
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

        public List<Time> GetTimes() 
        {
            return _times;
        }

        public void AddTime(Time time)
        {
            _times.Add(time);
        }

        public void UpdateTime(Time time)
        {
            //finding time entry to update 
            Time? existingTime = _times?.FirstOrDefault(t => t.ProjectId == time.ProjectId && 
                                   t.EmployeeId == time.EmployeeId);

            if (existingTime != null)
            {
                existingTime.Date = time.Date;
                existingTime.Narrative = time.Narrative;
                existingTime.Hours = time.Hours;
            }
        }

        public void DeleteTime(Time time)
        {
            _times?.Remove(time);
        }
    }
}
