using Api_Basica.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}
