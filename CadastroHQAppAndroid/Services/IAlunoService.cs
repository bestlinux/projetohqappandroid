using CadastroHQAppAndroid.Data;

namespace CadastroHQAppAndroid.Services;

public interface IAlunoService
{
    Task InitializeAsync();
    Task<List<Aluno>> GetAlunos();
    Task<Aluno> GetAlunoById(int alunoId);
    Task<int> AddAluno(Aluno aluno);
    Task<int> UpdateAluno(Aluno aluno);
    Task<int> DeleteAluno(Aluno aluno);
}
