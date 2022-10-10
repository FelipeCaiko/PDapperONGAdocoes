using Dapper;
using PDapperONGAdocoes.Config;
using PDapperONGAdocoes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDapperONGAdocoes.Repository
{
    public class AdocoesRepository : IAdocoesRepository
    {
        private string _conn;

        public AdocoesRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(Adocoes adocoes)
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Adocoes.INSERT, adocoes);
                result = true;
            }
            return result;
        }

        public bool Delete(int id)
        {
            using (var db = new SqlConnection(_conn))
            {
                var query = $"DELETE FROM Adocoes WHERE ID = '{id}'";
                db.Execute(query);
                return true;
            }
        }

        public List<Adocoes> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var adocoes = db.Query<Adocoes>(Adocoes.SELECT);
                return (List<Adocoes>)adocoes;
            }
        }
    }
}
