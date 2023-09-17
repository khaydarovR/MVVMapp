namespace MVVMapp.App.Models
{
    public class Lesson
    {
        static int count = 0;
        public int Id { get; set; } = count;
        public string Name { get; set; } = "Название пары";
        public string Locate { get; set; } = "403";
        public LessonTypeEnum LessonTypeEnum { get; set; } = LessonTypeEnum.Лабы;
        public string TeacherName { get; set; } = "B.D Иванов";
        public TimeOnly StartTime { get; set; } = TimeOnly.Parse("13:30");

        public Lesson()
        {
            count++;
        }

    }
}
