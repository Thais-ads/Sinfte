using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinFTE.Models;
using SinFTE.Repositorios.Interfaces;

namespace SinFTE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;
        public MarcaController(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;

        }
        [HttpGet]
        public async Task<ActionResult<List<MarcaModel>>> BuscarTodasMarcas()
        {
            List<MarcaModel> marcas = await _marcaRepositorio.BuscarTodasMarcas();
            return Ok(marcas);
        }

        [HttpPost]
        public async Task<ActionResult<MarcaModel>> Adicionar([FromBody] MarcaModel marcaModel)
        {
            MarcaModel marca = await _marcaRepositorio.Adicionar(marcaModel);
            return Ok(marca);
        }

        [HttpPut]
        public async Task<ActionResult<MarcaModel>> Atualizar([FromBody] MarcaModel marcaModel)
        {
            
            MarcaModel marca = await _marcaRepositorio.Atualizar(marcaModel);
            return Ok(marca);
        }
    }
}
