using FitSync.Domain.Entities;
using FitSync.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FitSync.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioRepository _repository;

        public ExercicioController(IExercicioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var exercicios = await _repository.ObterTodosAsync();
            return Ok(exercicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var exercicio = await _repository.ObterPorIdAsync(id);

            if (exercicio == null)
                return NotFound(new { mensagem = "Exercicio não encontrado." });

            return Ok(exercicio);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Exercicio exercicio)
        {
            exercicio.Id = Guid.NewGuid();

            await _repository.AdicionarAsync(exercicio);
            return CreatedAtAction(nameof(ObterPorId), new { id = exercicio.Id }, exercicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] Exercicio exercicio)
        {
            if (id != exercicio.Id)
                return BadRequest("O ID da URL não bate com o ID do corpo da requisição.");

            var exercicioExistente = await _repository.ObterPorIdAsync(id);
            if (exercicioExistente == null)
                return NotFound("Registro de exercicio não encontrado.");

            await _repository.AtualizarAsync(exercicio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var exercicioExistente = await _repository.ObterPorIdAsync(id);
            if (exercicioExistente == null)
                return NotFound();

            await _repository.RemoverAsync(id);
            return NoContent();
        }
    }
}