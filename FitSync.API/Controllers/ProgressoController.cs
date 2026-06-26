using FitSync.Domain.Entities;
using FitSync.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FitSync.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressoController : ControllerBase
    {
        private readonly IProgressoRepository _repository;

        public ProgressoController(IProgressoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var progressos = await _repository.ObterTodosAsync();
            return Ok(progressos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var progresso = await _repository.ObterPorIdAsync(id);

            if (progresso == null)
                return NotFound(new { mensagem = "Progresso não encontrado." });

            return Ok(progresso);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Progresso progresso)
        {
            progresso.Id = Guid.NewGuid();
            progresso.DataRegistro = DateTime.UtcNow;

            await _repository.AdicionarAsync(progresso);
            return CreatedAtAction(nameof(ObterPorId), new { id = progresso.Id }, progresso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] Progresso progresso)
        {
            if (id != progresso.Id)
                return BadRequest("O ID da URL não bate com o ID do corpo da requisição.");

            var progressoExistente = await _repository.ObterPorIdAsync(id);
            if (progressoExistente == null)
                return NotFound("Registro de progresso não encontrado.");

            progresso.DataRegistro = progressoExistente.DataRegistro;
            progresso.AlunoId = progressoExistente.AlunoId;
            progresso.ExercicioId = progressoExistente.ExercicioId;

            await _repository.AtualizarAsync(progresso);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var progressoExistente = await _repository.ObterPorIdAsync(id);
            if (progressoExistente == null)
                return NotFound();

            await _repository.RemoverAsync(id);
            return NoContent();
        }
    }
}