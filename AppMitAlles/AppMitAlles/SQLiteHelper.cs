using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AppMitAlles
{
    internal class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<AutoModel>().Wait();
        }

        public Task<List<AutoModel>> GetCarsAsync()
        {
            return db.Table<AutoModel>().ToListAsync();
        }

        //CREATE OR UPDATE
        public Task<int> SaveCarAsync(AutoModel auto)
        {
            if (auto.Id != 0)
            {
                return db.UpdateAsync(auto);
            }
            else
            {
                return db.InsertAsync(auto);
            }
        }

        //GET ITEMS
        public Task<AutoModel> GetCarAsync(int Id)
        {
            return db.Table<AutoModel>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        //DELETE
        public Task<int> DeleteCarAsync(AutoModel auto)
        {
            return db.DeleteAsync(auto);
        }
    }
}
