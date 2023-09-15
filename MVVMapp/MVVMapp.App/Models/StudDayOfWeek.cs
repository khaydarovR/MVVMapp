namespace MVVMapp.App.Models
{
    public class StudDayOfWeek
    {
        public string Group { get; set; } = "4201133";
        public System.DayOfWeek DayInWeek { get; set; } = DayOfWeek.Monday;
        public WeekTypeEnum WeekType { get; set; } = WeekTypeEnum.Вверхняя;
        public List<Lesson> Lessons { get; set; }= new List<Lesson>();
    }
}
