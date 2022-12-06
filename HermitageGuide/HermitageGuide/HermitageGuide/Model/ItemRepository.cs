using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace HermitageGuide.Model
{
    public class ItemRepository
    {
        SQLiteConnection database;
        static object locker = new object();

        public ItemRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            //database.CreateTable<ItemInfo>();
        }

        public void CreateTable()
        {
            database.CreateTable<ItemInfo>();
        }

        public List<ItemInfo> GetItems()
        {
            return database.Table<ItemInfo>().ToList();
        }
        public ItemInfo GetItem(int id)
        {
            return database.Get<ItemInfo>(id);
        }
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<ItemInfo>(id);
            }
        }
        public int SaveItem(ItemInfo item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
