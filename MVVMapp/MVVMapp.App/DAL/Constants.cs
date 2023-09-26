using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMapp.App.DAL
{
    public static class Constants
    {
        public const string DatabaseFilename = "ScheduleSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const string KeyGroup = "groupNum";
        public const string KeyTimer = "timerForNotify";
        public const string KeySubGroup = "subGroup";
    }

    public enum RussianDayOfWeek
    {
        Воскресенье = 0, // Sunday
        Понедельник = 1, // Monday
        Вторник = 2, // Tuesday
        Среда = 3, // Wednesday
        Четверг = 4, // Thursday
        Пятница = 5, // Friday
        Суббота = 6  // Saturday
    }
}
