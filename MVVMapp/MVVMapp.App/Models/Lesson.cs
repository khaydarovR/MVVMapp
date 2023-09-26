namespace MVVMapp.App.Models
{
    public class Lesson
    {
        static int count = 0;
        public int Id { get; set; } = count;
        public string Name { get; set; } = "Название пары";
        public string Locate { get; set; }
        public LessonTypeEnum LessonTypeEnum { get; set; }
        public string TeacherName { get; set; }
        public DateTime StartTime { get; set; }

        public Lesson()
        {
            count++;
        }

    }
}
