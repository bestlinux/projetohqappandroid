using SQLite;
using System.ComponentModel.DataAnnotations;
namespace CadastroHQAppAndroid.Data;

public class Aluno
{
    [PrimaryKey, AutoIncrement]
    public int AlunoId { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Endereco { get; set; }
    [Required]
    public string Genero { get; set; }
}
