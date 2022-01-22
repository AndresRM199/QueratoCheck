using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using QueratoCheck.Model;

namespace QueratoCheck.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Information>().Wait();
           
        }

        public Task<List<Information>> GetNotesAsync()
        {
            return _database.Table<Information>().ToListAsync();
        }

        public Task<Information> GetNoteAsync(int id)
        {
            return _database.Table<Information>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Information note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Information note)
        {
            return _database.DeleteAsync(note);
        }
    }
}