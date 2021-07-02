using M335.Classes;
using M335.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M335.Services
{
    public class ItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ItemDatabase> Instance = new AsyncLazy<ItemDatabase>(async () =>
        {
            var instance = new ItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Item>();
            return instance;
        });

        public ItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Item>> GetItemsAsync()
        {
            Database.Table<Item>();
            return Database.Table<Item>().OrderByDescending(itm => itm.Id).ToListAsync();
        }

        public Task<List<Item>> GetItemsNotDoneAsync()
        {
            // M335 mit einem Select
            return Database.QueryAsync<Item>("SELECT * FROM [Item] WHERE [Id] = 0");
        }

        public Task<Item> GetItemAsync(int id)
        {
            return Database.Table<Item>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item != null)
            {
                if (item.Id != 0)
                {
                    return Database.UpdateAsync(item);
                }
                else
                {
                    return Database.InsertAsync(item);
                }
            }
            return null;
        }

        public Task<int> DeleteItemAsync(Item item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
