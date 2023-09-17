using MVVMapp.App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMapp.App.DAL
{
    public class UserSettingsDB
    {
        SQLiteAsyncConnection Database;

        public UserSettingsDB()
        {

        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Lesson>();
        }

        public async Task<List<Lesson>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<Lesson>().ToListAsync();
        }


        public async Task<int> SaveItemAsync(Lesson item)
        {
            await Init();
            if (item.Name == "")
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }
    }
}
