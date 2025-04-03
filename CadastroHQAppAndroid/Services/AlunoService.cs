using CadastroHQAppAndroid.Data;
using SQLite;

namespace CadastroHQAppAndroid.Services;

public class AlunoService : IAlunoService
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

                await _dbConnection.CreateTableAsync<Aluno>();
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

    public async Task<int> AddAluno(Aluno aluno)
    {
        return await _dbConnection.InsertAsync(aluno);
    }

    public async Task<int> DeleteAluno(Aluno aluno)
    {
        return await _dbConnection.DeleteAsync(aluno);
    }
    public async Task<int> UpdateAluno(Aluno aluno)
    {
        return await _dbConnection.UpdateAsync(aluno);
    }
    public async Task<List<Aluno>> GetAlunos()
    {
        return await _dbConnection.Table<Aluno>().ToListAsync();
    }

    public async Task<Aluno> GetAlunoById(int alunoId)
    {
        var aluno = await _dbConnection.QueryAsync<Aluno>($"Select * From {nameof(Aluno)} where AlunoID={alunoId} ");
        return aluno.FirstOrDefault();
    }
}
