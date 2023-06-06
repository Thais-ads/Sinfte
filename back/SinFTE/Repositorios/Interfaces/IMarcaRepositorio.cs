using SinFTE.Models;

namespace SinFTE.Repositorios.Interfaces
{
    public interface IMarcaRepositorio
    {
        Task<List<MarcaModel>> BuscarTodasMarcas();
        Task<MarcaModel> BuscarMarcaPorId(int id_marca);
        Task<MarcaModel> Adicionar(MarcaModel marca);
     
        Task<bool> Apagar(int id_marca);
        Task<MarcaModel> Atualizar(MarcaModel marcaModel);
    }
}
