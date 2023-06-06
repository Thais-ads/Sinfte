using Microsoft.EntityFrameworkCore;
using SinFTE.Data;
using SinFTE.Models;
using SinFTE.Repositorios.Interfaces;

namespace SinFTE.Repositorios
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly SinFTEDBContext _dbContext;
        public MarcaRepositorio(SinFTEDBContext sinFteDBContext)
        {
            _dbContext = sinFteDBContext;
        }
        public async Task<MarcaModel> BuscarMarcaPorId(int id_model)
        {
            return await _dbContext.MARCAS.FirstOrDefaultAsync(x => x.Id_marca == id_model);
        }

        public async Task<List<MarcaModel>> BuscarTodasMarcas()
        {
            return await _dbContext.MARCAS.ToListAsync();
        }

        public async Task<MarcaModel> Adicionar(MarcaModel marca)
        {
            _dbContext.MARCAS.Add(marca);
            await _dbContext.SaveChangesAsync();

            return marca;
        }
        public async Task<MarcaModel> Atualizar(MarcaModel marca)
        {
            MarcaModel marcaPorId = await BuscarMarcaPorId(marca.Id_marca);

            if (marcaPorId == null)
            {
                throw new Exception($"Usuário para o ID: {marcaPorId} não foi encontrado no Banco de Dados.");
            }

            marcaPorId.Marca = marca.Marca;
            marcaPorId.Lojas = marca.Lojas;

            _dbContext.MARCAS.Update(marcaPorId);
            await _dbContext.SaveChangesAsync();

            return marcaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            MarcaModel marcaPorId = await BuscarMarcaPorId(id);

            if (marcaPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.MARCAS.Remove(marcaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
