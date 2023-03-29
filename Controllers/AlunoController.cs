namespace ExerciciosSemana8.Controllers;
using ExerciciosSemana8.Repository;
using ExerciciosSemana8.Model;
using Microsoft.AspNetCore.Mvc;
using ExercicioSemana8.Dtos;

[ApiController]
[Route("[Controller]")]
public class AlunoController : ControllerBase
{

    [HttpGet]
    public IActionResult Listar(string? nome)
    {
        var repository = new AlunoRepository();
        var alunos = repository.ListarAlunos(nome);

        return Ok(alunos);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Obter(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Id deve ser maior zero!");
        }
        var repository = new AlunoRepository();
        var aluno = repository.ObterPorId(id);

        if (aluno == null)
        {
            return NotFound();
        }
        return Ok(aluno);
    }
    [HttpPost]
    public IActionResult Criar([FromBody] AlunoDto dto)
    {
        var repository = new AlunoRepository();
        var aluno = repository.CriarAluno(dto);

        return CreatedAtAction(nameof(AlunoController.Obter), new { id = aluno.Id }, aluno);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Excluir(int id){
        var repository =  new AlunoRepository();
        repository.ExcluirAluno(id);
        return NoContent();      
    }
}