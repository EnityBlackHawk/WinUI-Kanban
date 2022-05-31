using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Windows.Storage;

namespace WinUI_Sample.Model
{
    public class DataBaseService
    {
        SQLiteAsyncConnection _connection;

        private async Task Init()
        {
            if (_connection != null) return;
            var dataBasePath = Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            dataBasePath += "\\DataBase.db";
            System.Diagnostics.Debug.WriteLine(dataBasePath);

            _connection = new SQLiteAsyncConnection(dataBasePath);

            await _connection.CreateTableAsync<Model.ItemModel>();
        }

        public DataBaseService()
        {
            Init();
        }

        public async Task Add<T>(T obj)
        {
            var index = await _connection.InsertAsync(obj, typeof(T));
            
        }

        public async Task RemoveAll<T>()
        {
            await _connection.DeleteAllAsync<T>();
        }

        public async Task Update<T>(IEnumerable<T> values)
        {
            await _connection.UpdateAllAsync(values);
        }

        public async Task<ICollection<T>> GetAsync<T>() where T:new()
        {
            return await _connection.Table<T>().ToListAsync();
        }

    }
}
