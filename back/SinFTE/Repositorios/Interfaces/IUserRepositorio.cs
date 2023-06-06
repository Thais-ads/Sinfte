using SinFTE.Models;

namespace SinFTE.Repositorios.Interfaces
{
    public interface IUserRepositorio
    {

        Task<List<UserModel>> BuscarTodosUsuarios();
        Task<UserModel> BuscarUsuario(string nome_completo, string senha);
        Task<UserModel> Atualizar(UserModel user, int id_usuario);
        Task<UserModel> Adicionar();

        Task<bool> Apagar(int id_usuario);
    }
}
