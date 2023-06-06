using Microsoft.EntityFrameworkCore;
using SinFTE.Data;
using SinFTE.Models;
using SinFTE.Repositorios.Interfaces;

namespace SinFTE.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly SinFTEDBContext _dbContext;
        public UserRepositorio(SinFTEDBContext sinFTEDBContext)
        {
            _dbContext = sinFTEDBContext;
        }

        public async Task<List<UserModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.USUARIOS.ToListAsync();
        }

        public async Task<UserModel> BuscarUsuario(string nome_completo, string senha)
        {

            return await _dbContext.USUARIOS.FirstOrDefaultAsync(x => x.Nome_completo == nome_completo && x.Senha == senha);

        }

        public Task<UserModel> Adicionar()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Atualizar(UserModel user, int id_usuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int id_usuario)
        {
            throw new NotImplementedException();
        }
    }
}
