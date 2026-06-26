using FitSync.Domain.Entities;
using FitSync.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FitSync.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoController : ControllerBase
    {
        private readonly ITreinoRepository _repository;

        public TreinoController(ITreinoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var treinos = await _repository.ObterTodosAsync();
            return Ok(treinos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var treino = await _repository.ObterPorIdAsync(id);

            if (treino == null)
                return NotFound(new { mensagem = "Treino não encontrado." });

            return Ok(treino);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] Treino treino)
        {
            treino.Id = Guid.NewGuid();
            treino.DataCriacao = DateTime.UtcNow;

            await _repository.AdicionarAsync(treino);
            return CreatedAtAction(nameof(ObterPorId), new { id = treino.Id }, treino);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] Treino treino)
        {
            if (id != treino.Id)
                return BadRequest("Inconsistência de IDs. O ID da URL não confere com o objeto.");

            var treinoExistente = await _repository.ObterPorIdAsync(id);
            if (treinoExistente == null)
                return NotFound("Treino não encontrado.");

            treino.DataCriacao = treinoExistente.DataCriacao;
            treino.AlunoId = treinoExistente.AlunoId;
            treino.PersonalId = treinoExistente.PersonalId;

            await _repository.AtualizarAsync(treino);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var treinoExistente = await _repository.ObterPorIdAsync(id);
            if (treinoExistente == null)
                return NotFound();

            await _repository.RemoverAsync(id);
            return NoContent();
        }
    }
}