using ExercicioSemana8.Dtos;
using ExercicioSemana8.Model;
namespace ExerciciosSemana8.Repository;

public class AlunoRepository
{

    private static List<AlunoModel> lista = new List<AlunoModel>(){
            new AlunoModel { Id = 1, Nome = "Emanuel", DataDeNascimeto =  DateTime.Now},
            new AlunoModel { Id = 2, Nome = "Manu", DataDeNascimeto =  DateTime.Today},
            new AlunoModel { Id = 3, Nome = "Manuel", DataDeNascimeto =  DateTime.Today},
            new AlunoModel { Id = 4, Nome = "Soso", DataDeNascimeto =  DateTime.Today}
        };

    public List<AlunoModel> ListarAlunos(string nome)
    {
        if (string.IsNullOrEmpty(nome))
        {
            return lista;
        }
        else
        {
            return lista.Where(e => e.Nome.ToUpper().Contains(nome.ToUpper()))
            .OrderBy(e => e.Id)
            .ToList();
        }
    }

    public AlunoModel ObterPorId(int id)
    {
        return lista.FirstOrDefault(x => x.Id == id);
    }

    public AlunoModel CriarAluno(AlunoDto dto)
    {
        var aluno = new AlunoModel();
        aluno.Id = CriarId();
        aluno.Nome = dto.Nome;
        aluno.DataDeNascimeto = DateTime.Now;

        lista.Add(aluno);
        return aluno;
    }

    public void ExcluirAluno(int id)
    {
        var aluno = lista.FirstOrDefault(d => d.Id == id);
        if (aluno != null)
            lista.Remove(aluno);

    }


    private int CriarId()
    {
        return lista.Last().Id + 1;
    }

}
