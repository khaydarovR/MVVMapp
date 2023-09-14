using MVVMapp.App.Models;

namespace MVVMapp.App.Services
{
    public class LessonsDataStore : ILessonsDataStore
    {
        readonly List<StudDayOfWeek> items;

        public LessonsDataStore()
        {
            var day1 = new StudDayOfWeek() { DayInWeek = DayOfWeek.Sunday, WeekType = WeekTypeEnum.Вверхняя };
            var day2 = new StudDayOfWeek() { DayInWeek = DayOfWeek.Tuesday, WeekType = WeekTypeEnum.Вверхняя };
            var day3 = new StudDayOfWeek() { DayInWeek = DayOfWeek.Wednesday, WeekType = WeekTypeEnum.Вверхняя };
            day1.Lessons.Add(new Lesson());
            items = new List<StudDayOfWeek>()
            {
                day1, day2, day3
            };
        }

        public async Task<bool> AddItemAsync(StudDayOfWeek item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }
            items.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(StudDayOfWeek item)
        {
            if (item == null) { throw new ArgumentNullException(nameof(item)); }

            var oldItem = items.Where((StudDayOfWeek arg) => arg.DayInWeek == item.DayInWeek && arg.WeekType == item.WeekType).FirstOrDefault();
            if (oldItem != null)
            {
                items.Remove(oldItem);
                items.Add(item);
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteItemAsync(StudDayOfWeek item)
        {

            var oldItem = items.Where((StudDayOfWeek arg) => arg.DayInWeek == item.DayInWeek && arg.WeekType == item.WeekType).FirstOrDefault();
            if (oldItem != null)
            {
                items.Remove(oldItem);
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<StudDayOfWeek?> GetItemAsync(DayOfWeek day, WeekTypeEnum weekTypeEnum)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.WeekType == weekTypeEnum && s.DayInWeek == day));
        }

        public async Task<IEnumerable<StudDayOfWeek>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}