using CadastroHQAppAndroid.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroHQAppAndroid.Services
{
    public class HQService : IHQService
    {
        private SQLiteAsyncConnection _dbConnection;

        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {

                var databasePath = Path.Combine(GetLocalFileDirectory(), "HQs.db3");

                try
                {
                    // Create the empty file; replace if exists.
                    _dbConnection = new SQLiteAsyncConnection(databasePath,
                                                 SQLiteOpenFlags.Create |
                                                 SQLiteOpenFlags.FullMutex |
                                                 SQLiteOpenFlags.ReadWrite);

                    await _dbConnection.CreateTableAsync<HQ>();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public string GetLocalFileDirectory()
        {
            var docFolder = FileSystem.AppDataDirectory;
            var libFolder = Path.Combine(docFolder, "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return libFolder;
        }

        public async Task<int> AddHQ(HQ hq)
        {
            return await _dbConnection.InsertAsync(hq);
        }

        public Task<int> DeleteHQ(HQ hq)
        {
            throw new NotImplementedException();
        }

        public async Task<HQ> GetHQById(int hqId)
        {
            var hq = await _dbConnection.QueryAsync<HQ>($"Select * From {nameof(HQ)} where HQId={hqId} ");
            return hq.FirstOrDefault();
        }

        public async Task<List<HQ>> GetHQS()
        {
            return await _dbConnection.Table<HQ>().ToListAsync();
        }

        public async Task<int> UpdateHQ(HQ hq)
        {
            return await _dbConnection.UpdateAsync(hq);
        }
    }
}
