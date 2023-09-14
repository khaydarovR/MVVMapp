using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVVMapp.App.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(DateOnly? date);
        Task<T?> GetItemAsync(DateOnly? date);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
