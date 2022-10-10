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
    public class PessoaRepository : IPessoaRepository
    {
        private string _conn;

        public PessoaRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(Pessoa pessoa)
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Pessoa.INSERT, pessoa);
                result = true;
            }
            return result;
        }

        public Pessoa GetOne(string cpf)
        {
            Pessoa pessoa = new();

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var query = $"SELECT * FROM Pessoa WHERE CPF = {cpf}";
                pessoa = db.Query<Pessoa>(query).FirstOrDefault();

                if (pessoa != null)
                {
                    return pessoa;
                }
                return null;
            }
        }
        public bool Delete(string cpf)
        {
            using (var db = new SqlConnection(_conn))
            {
                var query = $"DELETE FROM Pessoa WHERE CPF = '{cpf}'";
                db.Execute(query);
                return true;
            }
        }

        public bool Update(string cpf, string parametro, string value)
        {
            using (var db = new SqlConnection(_conn))
            {
                var query = $"UPDATE Pessoa SET {parametro} = '{value}' WHERE CPF = '{cpf}'";
                db.Execute(query);
                return true;
            }
        }

        public List<Pessoa> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var pessoas = db.Query<Pessoa>(Pessoa.SELECT);
                return (List<Pessoa>)pessoas;
            }
        }
    }
}
