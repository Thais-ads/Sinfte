using Microsoft.EntityFrameworkCore;
using SinFTE.Data;
using SinFTE.Models;
using SinFTE.Repositorios.Interfaces;
using System;

namespace SinFTE.Repositorios
{
    public class LogRepositorio : ILogRepositorio
    {

        private readonly SinFTEDBContext _dbContext;
        public LogRepositorio(SinFTEDBContext sinFTEDBContext)
        {
            _dbContext = sinFTEDBContext;
        }


        public async Task<List<LogModel>> Marca(String marca)
        {                                                       //select * from log where Marcas ='Aramis'
            var select = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE MARCAS = {0} ", marca).ToListAsync();
            return select;
        }



        public async Task<List<LogModel>> BuscarPorData(String marca)
        {
            DateTime dataAtual = DateTime.Now;
            var novaDataStr = dataAtual.ToString("yyyy-MM-dd");

            if (marca == "todasmarcas")
            {
                var LOG = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE DATA_CRIACAO LIKE  {0}", $"{novaDataStr}%").ToListAsync();
                return LOG;

            }
            var select = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE MARCAS = {0} and DATA_CRIACAO LIKE {1}", marca, $"{novaDataStr}%").ToListAsync();
            return select;

        }
        public async Task<List<LogModel>> EssaSemana(String marca)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime novaData = dataAtual.AddDays(-7);
            string dataAtualStr = dataAtual.ToString("yyyy-MM-dd");
            string novaDataStr = novaData.ToString("yyyy-MM-dd");

            if (marca == "todasmarcas")
            {
                var sem = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE DATA_CRIACAO BETWEEN {0} AND {1}", novaDataStr, dataAtualStr).ToListAsync();
                return sem;

            }

            var select = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE MARCAS ={0} AND DATA_CRIACAO BETWEEN {1} and {2}", marca, novaDataStr, dataAtualStr).ToListAsync();
            return select;

        }

        public async Task<List<LogModel>> SemanaPassada (String marca)
        {
            DateTime dataAtual = DateTime.Now;
            DateTime semPassadaDiaFinal = dataAtual.AddDays(-7);
            DateTime semPassadaDiaInicial = semPassadaDiaFinal.AddDays(-7);

            string semPassadaDiaFinalStr = semPassadaDiaFinal.ToString("yyyy-MM-dd");
            string semPassadaDiaInicialStr = semPassadaDiaInicial.ToString("yyyy-MM-dd");

            if(marca == "todasmarcas")
            {
                var semPassada = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE DATA_CRIACAO BETWEEN {0} AND {1}", semPassadaDiaInicialStr, semPassadaDiaFinalStr).ToListAsync();
                return semPassada;

            }

            var select = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE MARCAS = {0} and DATA_CRIACAO BETWEEN {1} AND {2}", marca, semPassadaDiaInicialStr, semPassadaDiaFinalStr).ToListAsync();
            return select;


        }

        public async Task<List<LogModel>> mes(String marca)
        {
            DateTime mesAtual = DateTime.Now;

            string mesAtualStr = mesAtual.ToString("yyyy-MM");

            if(marca == "todasmarcas")
            {

                var LOG = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE DATA_CRIACAO LIKE {0}", $"{mesAtualStr}%").ToListAsync();
                return LOG;

            }

            var select = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE MARCAS = {0} AND DATA_CRIACAO LIKE {1}", marca, $"{mesAtualStr}%").ToListAsync();
            return select;

        }

        public async Task<List<LogModel>> mesPassado(String marca)
        {
            DateTime mesAtual = DateTime.Now;

            DateTime mesPassada = mesAtual.AddMonths(-1);
            string mesPassadaStr = mesPassada.ToString("yyyy-MM");

            if (marca == "todasmarcas")
            {
                var LOG = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE DATA_CRIACAO LIKE {0}", $"{mesPassadaStr}%").ToListAsync();
                return LOG;

            }

            var select = await _dbContext.LOG.FromSqlRaw("SELECT * FROM LOG WHERE MARCAS = {0} AND DATA_CRIACAO LIKE {1}", marca, $"{mesPassadaStr}%").ToListAsync();
            return select;




        }

        public async Task<LogModel> Adicionar(LogModel log)
        {
            await _dbContext.LOG.AddAsync(log);
            await _dbContext.SaveChangesAsync();

            return log;
        }

        public async Task<List<LogCard>> logMarcasOffOn()
        {

            DateTime diaAtual = DateTime.Now;

            string diaAtualStr = diaAtual.ToString("yyyy-MM-dd");

            var xBeacon = await _dbContext.LOGCARD.FromSqlRaw("SELECT l1.Marcas, SUM(l2.Qte_off) AS Qte_off, SUM(l2.Qte_caixas) - SUM(l2.Qte_off) AS Qte_on FROM (SELECT loja, Marcas, MAX(Data_criacao) AS Data_criacao FROM log WHERE Data_criacao LIKE {0} GROUP BY loja, Marcas) l1 JOIN log l2 ON l1.loja = l2.loja AND l1.Marcas = l2.Marcas AND l1.Data_criacao = l2.Data_criacao GROUP BY l1.Marcas;", $"{diaAtualStr}%").ToListAsync();

            return xBeacon;
        }


        public async Task<List<LogCard>> minutosquinze()
        {

 

                DateTime diaAtual = DateTime.Now;
                string diaAtualStr = diaAtual.ToString("yyyy-MM-dd");
                TimeSpan dataInicial = new TimeSpan(9, 0, 0);
                TimeSpan dataFinal = new TimeSpan(22, 0, 0);
                int minutosAdicionais = 15;

                List<LogCard> retorno = new List<LogCard>();

                while (dataInicial <= dataFinal)
                {
                    string horaAtualStr = dataInicial.ToString(@"hh\:mm");
                    string query = $"SELECT l1.Marcas, SUM(l2.Qte_off) AS Qte_off, SUM(l2.Qte_caixas) - SUM(l2.Qte_off) AS Qte_on, MAX(CAST(l1.Data_criacao AS TIME)) AS Data_criacao FROM (SELECT loja, Marcas, MAX(Data_criacao) AS Data_criacao FROM log WHERE Data_criacao LIKE '{diaAtualStr}%' GROUP BY loja, Marcas) l1 JOIN log l2 ON l1.loja = l2.loja AND l1.Marcas = l2.Marcas AND l1.Data_criacao = l2.Data_criacao GROUP BY l1.Marcas HAVING MAX(CAST(l1.Data_criacao AS TIME)) LIKE '{horaAtualStr}%';";

                    List<LogCard> resultado = await _dbContext.LOGCARD.FromSqlRaw(query).ToListAsync();
                    retorno.AddRange(resultado);

                    dataInicial = dataInicial.Add(TimeSpan.FromMinutes(minutosAdicionais));
                }

                return retorno;
            }



        
    }
}
