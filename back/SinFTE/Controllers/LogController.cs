using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinFTE.Models;
using SinFTE.Repositorios.Interfaces;

namespace SinFTE.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepositorio _logRepositorio;
        public LogController(ILogRepositorio logRepositorio)
        {
            _logRepositorio = logRepositorio;
        }



        [HttpGet("Empresa-marca")]
        public async Task<ActionResult<List<LogModel>>> Marca(String marca)
        {

            List<LogModel> sem = await _logRepositorio.Marca(marca);
            return Ok(sem);

        }

        [HttpGet("Hoje")]

        public async Task<ActionResult<List<LogModel>>> BuscarPorData(String marca)
        {
            List<LogModel> logs = await _logRepositorio.BuscarPorData( marca); //trazendo a data de hoje.
            return Ok(logs);


        }

        [HttpGet("EssaSemana")]
        public async Task<ActionResult<List<LogModel>>> EssaSemana(String marca)
        {

            List<LogModel> sem = await _logRepositorio.EssaSemana(marca);
            return Ok(sem);

        }

        [HttpGet("log-semanaPassada")]
        public async Task<ActionResult<List<LogModel>>> SemanaPassada(String marca )
        {

            List<LogModel> semPassada = await _logRepositorio.SemanaPassada(marca);
            return Ok(semPassada);

        }


        [HttpGet("log-mes")]
        public async Task<ActionResult<List<LogModel>>> mes(String marca)
        {
            List<LogModel> mes = await _logRepositorio.mes(marca);
            return Ok(mes);
        }


        [HttpGet("log-mesPassado")]
        public async Task<ActionResult<List<LogModel>>> mesPassado(String marca)
        {
            List<LogModel> mesPassado = await _logRepositorio.mesPassado(marca);
            return Ok(mesPassado);
        }


        [HttpGet("log-marcas-off-on")]
        public async Task<ActionResult<List<LogCard>>> logMarcasOffOn()
        {
            List<LogCard> logMarcas = await _logRepositorio.logMarcasOffOn();
            return Ok(logMarcas);
        }


        [HttpPost]

        public async Task<ActionResult<LogModel>> Adicionar([FromBody] LogModel logModel)
        {
            LogModel log = await _logRepositorio.Adicionar(logModel);
            return Ok(log);
        }


        [HttpGet("minutosquinze")]
        public async Task<ActionResult<List<LogCard>>> minutosquinze()
        {
            List<LogCard> logMarcas = await _logRepositorio.minutosquinze();
            return Ok(logMarcas);
        }





    }
}