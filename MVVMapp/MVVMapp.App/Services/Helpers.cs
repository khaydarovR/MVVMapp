using MVVMapp.App.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMapp.App.Services
{
    public static class Helpers
    {
        public static RussianDayOfWeek ToRussianDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return RussianDayOfWeek.Воскресенье;
                case DayOfWeek.Monday:
                    return RussianDayOfWeek.Понедельник;
                case DayOfWeek.Tuesday:
                    return RussianDayOfWeek.Вторник;
                case DayOfWeek.Wednesday:
                    return RussianDayOfWeek.Среда;
                case DayOfWeek.Thursday:
                    return RussianDayOfWeek.Четверг;
                case DayOfWeek.Friday:
                    return RussianDayOfWeek.Пятница;
                case DayOfWeek.Saturday:
                    return RussianDayOfWeek.Суббота;
                default:
                    throw new ArgumentOutOfRangeException(nameof(day), "Invalid day of week.");
            }
        }
    }
}
