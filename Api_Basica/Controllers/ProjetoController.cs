using Api_Basica.Data;
using Api_Basica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Basica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProjetoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Adiciona Um Novo Projeto
        [HttpPost]
        public async Task<IActionResult> AddProjeto(Projeto projeto)
        {
            // Pega os dados do UsuarioCriador
            var usuario = await _appDbContext.Usuarios
            .FirstOrDefaultAsync(u => u.Id == projeto.UsuarioCriadorId);

            // Verifica se o usuáriocriador existe
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            projeto.UsuarioCriador = usuario;

            _appDbContext.Projetos.Add(projeto);
            await _appDbContext.SaveChangesAsync();

            return Ok(projeto);
        }

        // Retorna uma lista com todos os projetos
        [HttpGet]
        public async Task<IActionResult> GetProjetos()
        {
            var projetos = await _appDbContext.Projetos
                .Include(p => p.UsuarioCriador)
                .ToListAsync();

            return Ok(projetos);
        }

        // Retorna uma lista de projetos a partir do Id do usuário criador
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetProjetosPorUsuario(int usuarioId)
        {
            var projetos = await _appDbContext.Projetos
                .Where(p => p.UsuarioCriadorId == usuarioId)
                .Include(p => p.UsuarioCriador)
                .ToListAsync();

            if (!projetos.Any())
                return NotFound("Nenhum projeto encontrado para esse usuário");

            return Ok(projetos);
        }

        // Atualiza um projeto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjeto(int id, [FromBody] Projeto projetoAtualizado)
        {
            var projetoExistente = await _appDbContext.Projetos
                .Include(p => p.UsuarioCriador)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (projetoExistente == null)
                return NotFound("Projeto não encontrado!");

            // Atualiza os campos
            projetoExistente.Nome = projetoAtualizado.Nome;
            projetoExistente.Descricao = projetoAtualizado.Descricao;

            // Atualiza usuário criador (se mudou)
            if (projetoExistente.UsuarioCriadorId != projetoAtualizado.UsuarioCriadorId)
            {
                var usuario = await _appDbContext.Usuarios
                    .FirstOrDefaultAsync(u => u.Id == projetoAtualizado.UsuarioCriadorId);

                if (usuario == null)
                    return BadRequest("Usuário não encontrado");

                projetoExistente.UsuarioCriadorId = usuario.Id;
                projetoExistente.UsuarioCriador = usuario;
            }

            await _appDbContext.SaveChangesAsync();

            return Ok(projetoExistente);
        }

        // Deleta um projeto existente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjeto(int id)
        {
            var projeto = await _appDbContext.Projetos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (projeto == null)
                return NotFound("Projeto não encontrado!");

            _appDbContext.Projetos.Remove(projeto);
            await _appDbContext.SaveChangesAsync();

            return Ok(projeto);
        }
    }
}
