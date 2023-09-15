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
            var result = await Database.CreateTableAsync<UserSetting>();
        }

        public async Task<List<UserSetting>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<UserSetting>().ToListAsync();
        }


        public async Task<int> SaveItemAsync(UserSetting item)
        {
            await Init();
            if (item.UserName == "")
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }
    }
}
