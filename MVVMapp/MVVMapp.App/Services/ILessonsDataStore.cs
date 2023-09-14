using MVVMapp.App.Models;

namespace MVVMapp.App.Services
{
    public interface ILessonsDataStore
    {
        Task<bool> AddItemAsync(StudDayOfWeek item);
        Task<bool> DeleteItemAsync(StudDayOfWeek item);
        Task<StudDayOfWeek?> GetItemAsync(DayOfWeek day, WeekTypeEnum weekTypeEnum);
        Task<IEnumerable<StudDayOfWeek>> GetItemsAsync(bool forceRefresh = false);
        Task<bool> UpdateItemAsync(StudDayOfWeek item);
    }
}