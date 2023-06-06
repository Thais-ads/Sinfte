using Microsoft.AspNetCore.Mvc;
using SinFTE.Models;

namespace SinFTE.Repositorios.Interfaces
{
    public interface ILogRepositorio
    {
        Task<List<LogModel>> BuscarPorData(String marca);
        Task<LogModel> Adicionar(LogModel log);
        Task<List<LogModel>> EssaSemana(String marca);
        Task<List<LogModel>> SemanaPassada(String marca);
        Task<List<LogModel>> mes(String marca);
        Task<List<LogModel>> mesPassado(String marca);
        Task<List<LogCard>> logMarcasOffOn();
        Task<List<LogModel>> Marca(String empresa);

        Task<List<LogCard>> minutosquinze();

    }
}
