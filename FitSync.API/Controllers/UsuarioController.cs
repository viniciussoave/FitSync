using FitSync.Domain.Entities;
using FitSync.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitSync.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var usuarios = await _repository.ObterTodosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var usuario = await _repository.ObterPorIdAsync(id);

            if (usuario == null)
                return NotFound(new { mensagem = "Usuário não encontrado." });

            return Ok(usuario);
        }

        [HttpPost("aluno")]
        public async Task<IActionResult> AdicionarAluno([FromBody] Aluno aluno)
        {
            aluno.Id = Guid.NewGuid();
            aluno.TipoUsuario = FitSync.Domain.Enum.TipoUsuario.Aluno;
            aluno.DataCriacao = DateTime.UtcNow;

            await _repository.AdicionarAsync(aluno);

            return CreatedAtAction(nameof(ObterPorId), new { id = aluno.Id }, aluno);
        }

        [HttpPost("personal")]
        public async Task<IActionResult> AdicionarPersonal([FromBody] Personal personal)
        {
            personal.Id = Guid.NewGuid();
            personal.TipoUsuario = FitSync.Domain.Enum.TipoUsuario.Personal;
            personal.DataCriacao = DateTime.UtcNow;

            await _repository.AdicionarAsync(personal);
            return CreatedAtAction(nameof(ObterPorId), new { id = personal.Id }, personal);
        }

        [HttpPut("aluno/{id}")]
        public async Task<IActionResult> AtualizarAluno(Guid id, [FromBody] Aluno aluno)
        {
            if (id != aluno.Id)
                return BadRequest("O ID da URL não bate com o ID do corpo da requisição.");

            var usuarioExistente = await _repository.ObterPorIdAsync(id);
            if (usuarioExistente == null)
                return NotFound("Aluno não encontrado.");

            aluno.TipoUsuario = usuarioExistente.TipoUsuario;
            aluno.DataCriacao = usuarioExistente.DataCriacao;

            await _repository.AtualizarAsync(aluno);
            return NoContent();
        }

        [HttpPut("personal/{id}")]
        public async Task<IActionResult> AtualizarPersonal(Guid id, [FromBody] Personal personal)
        {
            if (id != personal.Id)
                return BadRequest("O ID da URL não bate com o ID do corpo da requisição.");

            var usuarioExistente = await _repository.ObterPorIdAsync(id);
            if (usuarioExistente == null)
                return NotFound("Personal não encontrado.");

            personal.TipoUsuario = personal.TipoUsuario;
            personal.DataCriacao = personal.DataCriacao;

            await _repository.AtualizarAsync(personal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var usuarioExistente = await _repository.ObterPorIdAsync(id);
            if (usuarioExistente == null)
                return NotFound();

            await _repository.RemoverAsync(id);
            return NoContent();
        }
    }
}