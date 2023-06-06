using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinFTE.Models;
using SinFTE.Repositorios.Interfaces;

namespace SinFTE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        public UserController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;

        }
        [HttpGet("TodosUsuarios")]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {
            List<UserModel> usuarios = await _userRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("Usuario")]
        public async Task<ActionResult<UserModel>> BuscarUsuario(string nome_completo, string senha)
        {
            UserModel usuarios = await _userRepositorio.BuscarUsuario(nome_completo, senha);
            return Ok(usuarios);
        }

    }
}
