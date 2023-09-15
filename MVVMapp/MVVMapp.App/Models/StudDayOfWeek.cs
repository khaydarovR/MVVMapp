namespace MVVMapp.App.Models
{
    public class StudDayOfWeek
    {
        public System.DayOfWeek DayInWeek { get; set; }
        public WeekTypeEnum WeekType { get; set; }
        public List<Lesson> Lessons { get; set; }= new List<Lesson>();
    }
}
