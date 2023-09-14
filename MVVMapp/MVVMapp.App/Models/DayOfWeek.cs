using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Globalization;

namespace MVVMapp.App.Models
{
    public class StudDayOfWeek
    {
        public System.DayOfWeek DayInWeek { get; set; }
        public WeekTypeEnum WeekType { get; set; }
        public List<Lesson> Lessons { get; set; }= new List<Lesson>();
    }
}
