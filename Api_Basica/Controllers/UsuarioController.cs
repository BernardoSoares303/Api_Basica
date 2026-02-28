using Api_Basica.Data;
using Api_Basica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Basica.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuario(usuario usuario)
        {
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();

            return Ok(usuario);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<usuario>>> GetUsuarios()
        {
            var usuarios = await _appDbContext.Usuarios.ToListAsync();

            return Ok(usuarios);
        }

        [HttpGet("BuscarId/{id}")]

        public async Task<ActionResult<usuario>> GetUsuario(int id)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound("Usuario Não Encontrado!");
            }

            return Ok(usuario);
        }

        [HttpGet("BuscarNome/{nome}")]
        public async Task<ActionResult<IEnumerable<usuario>>> BuscarUsuarios(string nome)
        {
            var usuarios = await _appDbContext.Usuarios
                .Where(u => EF.Functions.Like(u.Nome, $"%{nome}%"))
                .ToListAsync();

            if (!usuarios.Any())
                return NotFound("Nome não encontrado!");

            return Ok(usuarios);
        }

        [HttpGet("BuscarRole/{role}")]
        public async Task<ActionResult<IEnumerable<usuario>>> BuscarUsuariosPorRole(string role)
        {
            var usuarios = await _appDbContext.Usuarios
                .Where(u => u.Role == role)
                .ToListAsync();

            if (!usuarios.Any())
                return NotFound("Role não encontrada!");

            return Ok(usuarios);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] usuario usuarioAtualizado)
        {
            var usuarioExistente = await _appDbContext.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
                return NotFound("Usuário não encontrado!");

            usuarioExistente.Nome = usuarioAtualizado.Nome;
            usuarioExistente.Email = usuarioAtualizado.Email;
            usuarioExistente.Role = usuarioAtualizado.Role;

            // Atualiza a senha diretamente
            usuarioExistente.Senha = usuarioAtualizado.Senha;

            await _appDbContext.SaveChangesAsync();

            return Ok(usuarioExistente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound("Usuário não encontrado!");

            _appDbContext.Usuarios.Remove(usuario);

            await _appDbContext.SaveChangesAsync();

            return Ok(usuario);
        }
    }
}
